namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNameValuesToMembershipTypeInDatabase : DbMigration
    {
        public override void Up()
        {
            Sql("Update MembershipTypes set Name='Pay as You GO' Where id=1 ");
            Sql("Update MembershipTypes set Name='Monthly' Where id=2 ");
            Sql("Update MembershipTypes set Name='Quarterly' Where id=3 ");
            Sql("Update MembershipTypes set Name='Annual' Where id=4 ");
        }
        
        public override void Down()
        {
        }
    }
}
