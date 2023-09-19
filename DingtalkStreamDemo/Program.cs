using DingtalkStreamDemo;

using Jusoft.DingtalkStream.Core;





IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddDingtalkStream(options =>
        {

            //options.ClientId = "dingXXXXXXXXXXXXXXXXXX";
            //options.ClientSecret = "xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx";

            // options.UA = "dingtalk-stream-demo"; // ��չ���Զ����UA
            // options.Subscriptions.Add //  ���ģ�Ҳ��������������

            options.AutoReplySystemMessage = true; // �Զ��ظ� SYSTEM ����Ϣ��ping,disconnect��

        }).RegisterEventSubscription()  // ע���¼����� ����ѡ��
          .RegisterCardInstanceCallback()// ע�ῨƬ�ص� ����ѡ��
          .RegisterIMRobotMessageCallback()// ע���������Ϣ�ص� ����ѡ�� // ��Ҫ��� Jusoft.DingtalkStream.Robot ��
          .AddMessageHandler<DefaultMessageHandler>() //�����Ϣ�������
          .AddHostServices();// ������������������� DingtalkStreamClient

    })
    .Build();

await host.RunAsync();
