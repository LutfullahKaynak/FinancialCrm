using FinancialCrm.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinancialCrm
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }
        FinancialCrmDbEntities db = new FinancialCrmDbEntities();

        private void btnEntry_Click(object sender, EventArgs e)
        {
            string nameUser = txtUserName.Text;
            string parola = txtPassword.Text;
            var record = db.Users.Where(x => x.Username == nameUser).FirstOrDefault();
            if (record is null)
            {
                MessageBox.Show("Geçersiz kullanıcı adı! Tekrar deneyiniz");
            }

            else 
            {
                if ((nameUser == record.Username.ToString()) && (parola == record.Password.ToString()))
                {
                    FrmDashboard fd = new FrmDashboard();
                    fd.Show();
                    this.Hide();


                    //Application.Run(new FrmDashboard());
                    //label3.Text = "MAYA";
                }

                else
                {
                    MessageBox.Show("Lütfen girdiğiniz bilgileri kontrol edip tekrar deneyin", "Hatalı Giriş", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            // var pcode = db.Users.Where(x => x.Password == parola).FirstOrDefault();
            
           
           
                //db.Users.Select(x=>x.Username).
        }
    }
}
