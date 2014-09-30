fmain.cs

//public mAppControl AppControl = mAppControl.Instance;

//when load main form 
//fAuth _auth = null;
//if (AppControl._Settings.RememberUser)
//{
//    _auth = new fAuth(AppControl._Settings.RememberUser, AppControl._Settings.UserProfil.UserName, AppControl._Settings.UserProfil.Password);
//}
//else
//{
//    _auth = new fAuth();
//}
//_auth.ShowDialog();

fauth.cs

  private bool RememberUser = false;
  private string UserName = "";
  private string Password = "";
  public fauth(bool RememberUser, string UserName, string Password)
  {
    this.RememberUser = RememberUser;
    this.UserName = UserName;
    this.Password = Password;
  }
  
  //when load fauth
  
  if (RememberUser)
  {
    checkBox1.Checked = true;
    textBox1.Text = UserName;
    textBox2.Text = Password;
  }
  else
  {
    checkBox1.Checked = false;
    textBox1.Text = "";
    textBox2.Text = "";
  }
  
  //when click authorize_button
  
  if (mAppController.Instance._UserController.UserAuth(textBox1.Text, textBox2.Text))
  {
    this.Close();
  }
