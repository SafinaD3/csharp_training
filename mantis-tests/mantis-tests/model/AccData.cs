using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinqToDB.Mapping;

namespace mantis_tests
{
    [Table(Name = "mantis_user_table")]
    public class AccData
    {
        public AccData()
        {
        }

        public AccData(string username, string password)
        {
            Name = username;
            Pass = password;
        }

        [Column(Name = "id"), PrimaryKey, Identity]
        public string Id { get; set; }

        [Column(Name = "username")]
        public string Name { get; set; }

        [Column(Name = "password")]
        public string Pass { get; set; }

        [Column(Name = "email")]
        public string Email { get; set; }

        public static List<AccData> GetAll()
        {
            using (BugtrackerDB db = new BugtrackerDB())
            {
                return (from g in db.Users select g).ToList();
            }
        }
    }

    public class AccountData
    {
        private string username;
        private string password;

        public AccountData(string username, string password)
        {
            this.username = username;
            this.password = password;
        }

        public string Username
        {
            get
            {
                return username;
            }
            set
            {
                username = value;
            }
        }

        public string Password
        {
            get
            {
                return password;
            }
            set
            {
                password = value;
            }
        }
    }
}
