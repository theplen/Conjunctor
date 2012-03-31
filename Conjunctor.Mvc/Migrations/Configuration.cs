namespace Conjunctor.Mvc.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Data.SqlClient;
    using System.Linq;
    using Conjunctor.Mvc.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<ConjunctorContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(ConjunctorContext context)
        {
            // Ugly hack to get around an automatic migrations bug that tries
            // execute this command every time Application_Start fires.
            try
            {
                context.Database.ExecuteSqlCommand("ALTER TABLE MeetingAttachments ADD CONSTRAINT UX_Hash UNIQUE(Hash)");
            }
            catch (SqlException ex)
            {
                if (ex.Number != 2714)
                {
                    throw;
                }
            }
        }
    }
}
