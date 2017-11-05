namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class seedusers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
 INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'1a6c0588-43cc-4146-a576-a75da8ed572c', N'admin@vidly.com', 0, N'ADEt3sEb8IrGubDzFFhK1jmiFYglkZX1SLKdLXgQAWFNsm551dwAlqCSASr4PhS+tg==', N'8fd3d302-e6c0-470f-9edb-9ab224299a9d', NULL, 0, 0, NULL, 1, 0, N'admin@vidly.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'9505d0de-b449-414a-ac86-25e1d74465ec', N'user@vidly.com', 0, N'ANskMGtwVdukka135d1Rj4tiOCf0bM9SegGv/C6jBdLl+eizuoCa8vkuMV1QFB/l1A==', N'dcbfaf7b-a446-4bb2-ac3d-0c23aa0b9451', NULL, 0, 0, NULL, 1, 0, N'user@vidly.com')

INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'236519dd-505d-4230-9a5f-7ca378eda7d8', N'CanManageMovies')

INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'1a6c0588-43cc-4146-a576-a75da8ed572c', N'236519dd-505d-4230-9a5f-7ca378eda7d8')

            ");
        }
        
        public override void Down()
        {
        }
    }
}
