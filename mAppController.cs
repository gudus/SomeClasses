public class mAppController
    {
        public UserController _UserController;
        public Settings _Settings;
        public mLocalDB _mLocalDB;

        #region Singlton

        private static readonly mAppController _instance = new mAppController();

        protected mAppController()
        {
            _UserController = new UserController();
            _mLocalDB = mLocalDB.Instance;
            if (_mLocalDB.SetConnection("BaseMeasurements"))
            {
                _Settings = Settings.Instance;
                _Settings.LoadSettingsFromLocalBase();
            }
            else
            {
                throw new Exception("Не удается подключиться к базе");
            }
        }

        public static mAppController Instance
        {
            get { return _instance; }
        }

        #endregion

        private void test()
        {
            //mNetwork.Mail.MailController mail = new mNetwork.Mail.MailController();
        }
    }

    public class User
    {
        /// <summary>
        /// Id пользователя (если используется центральная база),если нет то = UserName
        /// </summary>
        public string UserId { get; set; }
        /// <summary>
        /// Email пользователя
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// Имя пользователя
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// Пароль
        /// </summary>
        public string Password { get; set; }
        /// <summary>
        /// Ключ приложения
        /// </summary>
        public string AppKey { get; set; }
        /// <summary>
        /// Мобильный телефон
        /// </summary>
        public string MobilePhone { get; set; }
    }

    public class UserController : User
    {
        /// <summary>
        /// Авторизация пользователя
        /// </summary>
        /// <param name="UserName"></param>
        /// <param name="Password"></param>
        /// <returns></returns>
        public bool UserAuth(string UserName, string Password)
        {

            return true;
        }
        /// <summary>
        /// Регистрация пользователя
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public bool UserRegistration(User user)
        {

            return true;
        }
        /// <summary>
        /// Удаление пользователя
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public bool UserDeleteUser(User user)
        {

            return true;
        }
        /// <summary>
        /// Получить пользователя
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public User UserGet(User user)
        {

            return new User();
        }
        /// <summary>
        /// Получить список пользователей
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public List<User> UserGetList()
        {

            return new List<User>();
        }
        /// <summary>
        /// Удалить всех пользователей
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public List<User> UserDeleteAll()
        {

            return new List<User>();
        }
    }

    public class Settings
    {
        #region Singlton

        private static readonly Settings _instance = new Settings();

        protected Settings()
        {
        }

        public static Settings Instance
        {
            get { return _instance; }
        }

        #endregion

        public mNetwork.Mail.MailServer MailServer { get; set; }

        public bool AppLocked { get { return _AppLocked; } set { _AppLocked = value; } }
        private bool _AppLocked = true;

        public string LastLogginedUser { get; set; }

        public string DataBase { get; set; }

        public bool RememberUser { get { return _RememberUser; } set { _RememberUser = value; } }
        private bool _RememberUser = false;

        public User UserProfil { get; set; }

        public void LoadSettingsFromLocalBase()
        {
            #region get user
            #endregion

            #region get other setting

            #endregion
        }

        public void SaveSettingsFromLocalBase()
        {
            #region get user
            #endregion

            #region get other setting

            #endregion
        }
    }
