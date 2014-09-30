using System.IO;
using System.Net;
using System.Net.Mail;
    
    public class mNetwork
    {
        public class Mail
        {           
            /// <summary>
            /// Сервер отправки почты
            /// </summary>
            public class MailServer : Server
            {
                public MailServer(string ServerAdress, int ServerPort, string UserName, string UserPassword)
                    : base(ServerAdress, ServerPort, UserName, UserPassword)
                {
                }

                public MailServer()
                {
                }
                /// <summary>
                /// Использовать ssl
                /// </summary>
                public bool UseSsl { get { return _EnableSsl; } set { _EnableSsl = value; } }
                private bool _EnableSsl = false;
                /// <summary>
                /// DefaultCredentials
                /// </summary>
                public bool DefaultCredentials { get { return _DefaultCredentials; } set { _DefaultCredentials = value; } }
                private bool _DefaultCredentials = false;
            }
            /// <summary>
            /// Методы для отправки почты
            /// </summary>
            public class MailController : MailServer
            {
                /// <summary>
                /// Конструктор
                /// </summary>
                /// <param name="SMTPServer">SMTP сервер</param>
                /// <param name="UserName">Имя пользовател</param>
                /// <param name="UserPassword">Пароль пользователя</param>
                /// <param name="Port">Порт сервера</param>
                public MailController(string ServerAdress, int ServerPort, string UserName, string UserPassword)
                    : base(ServerAdress, ServerPort, UserName, UserPassword)
                {
                }
                /// <summary>
                /// Отправка письма
                /// </summary>
                /// <param name="emailTo"></param>
                /// <param name="emailFrom"></param>
                /// <param name="subject"></param>
                /// <param name="text"></param>
                public void Send(string emailTo, string emailFrom, string subject, string text)
                {
                    var smtp = new SmtpClient
                    {
                        Host = ServerAdress,
                        Port = ServerPort,
                        EnableSsl = UseSsl,
                        DeliveryMethod = SmtpDeliveryMethod.Network,
                        UseDefaultCredentials = DefaultCredentials,
                        Credentials = new NetworkCredential(UserName, UserPassword)
                    };
                    using (var message = new MailMessage(emailFrom, emailTo)
                    {
                        Subject = subject,
                        Body = text
                    })
                    {
                        smtp.Send(message);
                    }
                }
                /// <summary>
                /// Отправка письма с вложением
                /// </summary>
                /// <param name="emailTo"></param>
                /// <param name="emailFrom"></param>
                /// <param name="subject"></param>
                /// <param name="text"></param>
                /// <param name="attachment"></param>
                /// <param name="fileName"></param>
                public void Send(string emailTo, string emailFrom, string subject, string text, byte[] attachment, string fileName)
                {
                    Attachment att = new Attachment(new MemoryStream(attachment), fileName);
                    var smtp = new SmtpClient
                    {
                        Host = ServerAdress,
                        Port = ServerPort,
                        EnableSsl = UseSsl,
                        DeliveryMethod = SmtpDeliveryMethod.Network,
                        UseDefaultCredentials = DefaultCredentials,
                        Credentials = new NetworkCredential(UserName, UserPassword)
                    };
                    using (var message = new MailMessage(emailFrom, emailTo)
                    {
                        Subject = subject,
                        Body = text
                    })
                    {
                        message.Attachments.Add(att);
                        smtp.Send(message);
                    }
                }
            }
        }

        public class Http
        {
            public class HttpServer : Server
            {
                public HttpServer(string ServerAdress, int ServerPort, string UserName, string UserPassword)
                    : base(ServerAdress, ServerPort, UserName, UserPassword)
                {
                }
            }
        }

        public class Server
        {
            public Server()
            {
            }
            public Server(string ServerAdress, int ServerPort, string UserName, string UserPassword)
            {
                this.ServerAdress = ServerAdress;
                this.UserName = UserName;
                this.UserPassword = UserPassword;
                this.ServerPort = ServerPort;
            }
            /// <summary>
            /// Cервер
            /// </summary>
            public string ServerAdress { get; set; }
            /// <summary>
            /// Логин
            /// </summary>
            public string UserName { get; set; }
            /// <summary>
            /// Пароль
            /// </summary>
            public string UserPassword { get; set; }
            /// <summary>
            /// Порт
            /// </summary>
            public int ServerPort { get { return _ServerPort; } set { _ServerPort = value; } }
            private int _ServerPort = 0;
        }
    }
