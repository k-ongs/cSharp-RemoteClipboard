using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace RemoteClipboardServer
{
    class ClassSqlServer
    {
        private string where = "";
        private string limit = "";
        private string order = "";
        private string field = "*";
        // select * from table where id = 1 order by id;
        public SqlConnection sqlLink = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\DatabaseClipboard.mdf;Integrated Security=True;Connect Timeout=10");

        public ClassSqlServer Field(string str)
        {
            if(str != "")
                field = str;
            return this;
        }

        /// <summary>
        /// 根据某个字段排序
        /// </summary>
        /// <param name="str">字段名</param>
        /// <param name="sort">排序规则，默认为升序排序</param>
        /// <returns></returns>
        public ClassSqlServer Order(string str, bool sort = true)
        {
            if (str != "")
                order = " order by " + str + (sort ? " asc" : " desc");
            return this;
        }

        /// <summary>
        /// 根据字段条件查询数据
        /// </summary>
        /// <param name="str">条件</param>
        /// <returns></returns>
        public ClassSqlServer Where(string str)
        {
            if (str != "")
                where = " where " + str;
            return this;
        }

        /// <summary>
        /// 返回条数
        /// </summary>
        /// <param name="n"></param>
        /// <param name="m"></param>
        /// <returns></returns>
        public ClassSqlServer Limit(int n=0, int m=-1)
        {
            limit = " limit " + n.ToString() + (m < 0 ? "" : "," + m.ToString());
            return this;
        }

        public DataTable Select(string table)
        {
            string sql = "select " + field + " from " + table;
            if(where != "")
            {
                sql += where;
            }
            if (order != "")
            {
                sql += order;
            }

            if (limit != "")
            {
                sql += limit;
            }

            DataTable dataTable = new DataTable();
            try
            {
                this.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(sql, sqlLink);
                adapter.Fill(dataTable);
                this.Close();
            }
            catch(Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.ToString());
            }
            this.Clear();
            return dataTable;
        }

        public int Insert(string table, Dictionary<string, string> array)
        {
            int num = 0;
            string name = "";
            string value = "";

            if (array.Count > 0)
            {
                foreach (string key in array.Keys)
                {
                    name += (name == "" ? "" : ",") + key;
                    value += (value == "" ? "" : ",") + "'" + array[key] + "'";
                }
                string sql = "insert into " + table + "(" + name + ") VALUES(" + value + ")";
                try
                {
                    this.Open();
                    SqlCommand command = new SqlCommand(sql, sqlLink);
                    num = command.ExecuteNonQuery();
                    this.Close();
                }
                catch(Exception e){
                    System.Diagnostics.Debug.WriteLine(e.ToString());
                }
            }
            return num;
        }

        public int Update(string table, Dictionary<string, string> array)
        {
            int num = 0;
            string value = "";

            if (array.Count > 0)
            {
                foreach (string key in array.Keys)
                {
                    value += (value == "" ? "" : ",") + key + "='" + array[key] + "'";
                }
                string sql = "update " + table + " set " + value + " " + where;
                try
                {
                    this.Open();
                    SqlCommand command = new SqlCommand(sql, sqlLink);
                    num = command.ExecuteNonQuery();
                    this.Close();
                }
                catch { }
            }
            return num;
        }

        public int Delete(string table)
        {
            int num = 0;

            string sql = "delete from " + table + " " + where;
            try
            {
                this.Open();
                SqlCommand command = new SqlCommand(sql, sqlLink);
                num = command.ExecuteNonQuery();
                this.Close();
            }
            catch { }

            return num;
        }

        private void Open()
        {
            if (sqlLink.State == System.Data.ConnectionState.Closed)
            {
                sqlLink.Open();
            }
        }

        private void Close()
        {
            if (sqlLink.State == System.Data.ConnectionState.Open)
            {
                sqlLink.Close();
            }
        }

        private void Clear()
        {
            where = "";
            limit = "";
            order = "";
            field = "*";
        }
    }
}

/***
调用测试
ClassSqlServer sqlServer = new ClassSqlServer();

Dictionary<string, string> data = new Dictionary<string, string>();

data.Add("phone", "15213138243");
data.Add("password", "e10adc3949ba59abbe56e057f20f883e");
data.Add("binding", "1624325694");
System.Diagnostics.Debug.WriteLine(sqlServer.Insert("userInfo", data));

data["binding"] = "1624328888";
System.Diagnostics.Debug.WriteLine(sqlServer.Where("phone='15213138243'").Update("userInfo", data));

DataTable dataTable = sqlServer.Field("*").Select("userInfo");

string msg = dataTable.Rows[0][0].ToString() + " " + dataTable.Rows[0][1].ToString() + " " + dataTable.Rows[0][2].ToString() + " " + dataTable.Rows[0][3].ToString();
System.Diagnostics.Debug.WriteLine(msg);

System.Diagnostics.Debug.WriteLine(sqlServer.Where("phone='15213138243'").Delete("userInfo"));

数据表创建代码
create table userInfo(
    uid int IDENTITY(1001,1) primary key not null,
    phone varchar(11) not null,
    password varchar(32) not null,
    binding varchar(10)
);

create table userConfig(
	uid int not null references userInfo(uid),
	power int not null,
	cache nvarchar(max) not null,
	parse int not null,
	copy varchar(40) not null,
	paste varchar(40) not null,
	screenshot varchar(40) not null,
	color varchar(40) not null,
);

create table userDevice(
	did int IDENTITY(2020,1) primary key not null,
	name nvarchar(max) not null,
	mac varchar(12) not null,
	uid int not null references userInfo(uid),
	pid int not null,
);
***/