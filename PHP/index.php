<?php
require_once 'vendor/autoload.php';
use TencentCloud\Common\Credential;
use TencentCloud\Common\Profile\ClientProfile;
use TencentCloud\Common\Profile\HttpProfile;
use TencentCloud\Common\Exception\TencentCloudSDKException;
use TencentCloud\Sms\V20190711\SmsClient;
use TencentCloud\Sms\V20190711\Models\SendSmsRequest;
try {

    $cred = new Credential("AKID455zmUlw7C6qV740On7IJ9sY4QczKQPD", "vhJsKbEi1ARYmrlT0FwWvEQSJzUpzzAE");
    $httpProfile = new HttpProfile();
    $httpProfile->setEndpoint("sms.tencentcloudapi.com");
      
    $clientProfile = new ClientProfile();
    $clientProfile->setHttpProfile($httpProfile);
    $client = new SmsClient($cred, "", $clientProfile);

    $req = new SendSmsRequest();
    
    $params = array(
        "PhoneNumberSet" => array( "+8615213138243" ),
        "TemplateParamSet" => array( "123456", "5" ),
        "SmsSdkAppid" => "1400463955",
        "TemplateID" => "816615",
        "Sign" => "周雄的笔记"
    );
    $req->fromJsonString(json_encode($params));

    $resp = $client->SendSms($req);

    print_r($resp->toJsonString());
}
catch(TencentCloudSDKException $e) {
    echo $e;
}