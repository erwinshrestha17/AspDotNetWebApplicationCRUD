using System;
using System.Web.UI;

namespace WebApplication1.NewPages
{
    public partial class newIndex : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.Form["MethodName"] == "add")
                {
                    Btn_click();
                }
            }
        }

        private void Btn_click()
        {
            string fullName = Request.Form["FullName"]?.Trim();
            string email = Request.Form["Email"]?.Trim();
            string password = Request.Form["Password"]?.Trim();
            string phoneNumber = Request.Form["PhoneNumber"]?.Trim();
            string dateOfBirth = Request.Form["DateOfBirth"]?.Trim();
            
            
            
            
            
        }
    }
}