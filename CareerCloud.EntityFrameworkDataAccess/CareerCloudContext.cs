using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CareerCloud.Pocos;

namespace CareerCloud.EntityFrameworkDataAccess
{
    class CareerCloudContext: DbContext
    {
        public CareerCloudContext():
            base(@"Data Source=LAPTOP-6JLD6U9U\HUMBERBRIDGING;Integrated Security=True;")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SystemCountryCodePoco>().HasKey(n => n.Code);
            modelBuilder.Entity<SystemLanguageCodePoco>().HasKey(n => n.LanguageID);
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<ApplicantEducationPoco> ApplicantEducations { get; set; }

        public DbSet<ApplicantJobApplicationPoco> ApplicantJobApplications { get; set; }

        public DbSet<ApplicantProfilePoco> ApplicantProfiles { get; set; }

        public DbSet<ApplicantResumePoco> ApplicantResumes { get; set; }

        public DbSet<ApplicantSkillPoco> ApplicantSkills { get; set; }

        public DbSet<ApplicantWorkHistoryPoco> ApplicantWorkHistories { get; set; }

        public DbSet<CompanyDescriptionPoco> CompanyDescriptions { get; set; }

        public DbSet<CompanyJobDescriptionPoco> CompanyJobDescriptions { get; set; }

        public DbSet<CompanyJobEducationPoco> CompanyJobEducations { get; set; }

        public DbSet<CompanyJobPoco> CompanyJobs { get; set; }

        public DbSet<CompanyJobSkillPoco> CompanyJobSkills { get; set; }

        public DbSet<CompanyLocationPoco> CompanyLocations { get; set; }

        public DbSet<CompanyProfilePoco> CompanyProfiles { get; set; }

        public DbSet<SecurityLoginPoco> SecurityLogins { get; set; }

        public DbSet<SecurityLoginsLogPoco> SecurityLoginsLogs { get; set; }

        public DbSet<SecurityLoginsRolePoco> SecurityLoginsRoles { get; set; }

        public DbSet<SecurityRolePoco> SecurityRoles { get; set; }

        public DbSet<SystemCountryCodePoco> SystemCountryCodes { get; set; }

        public DbSet<SystemLanguageCodePoco> SystemLanguageCodes { get; set; }
    }
}
