using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace FAQ_Web_Api_Angular.Models
{


    public class Faq
    {
        [Key]
        public int id { get; set; }
        public string category { get; set; }
        public string question { get; set; }
        public string answer { get; set; }
        public int top { get; set; }

    }

    public class Question
    {
        [Key]
        public int id { get; set; }
        public string title { get; set; }
        public string question { get; set; }
        public string name { get; set; }
        public string email { get; set; }

    }



    public class FaqContext : DbContext
    {

        public FaqContext()
            : base("name=FaqDatabase")
        {
            Database.CreateIfNotExists();

        }

        public DbSet<Faq> Faqs { get; set; }
        public DbSet<Question> Questions { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }


    }
}
