namespace Studio_Line.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'30c2be43-6e4a-439a-86db-4db7ee6580da', N'guest@domain.com', 0, N'AIwbKe5ejdN0SnKylKcDx7HpG3U1Q3XfEvdjgkSdxTDsBgp9Q8eLB7Njo1kaO9hjZg==', N'7559dc17-bd4b-420c-ae98-dd1a56219a75', NULL, 0, 0, NULL, 1, 0, N'guest@domain.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'7d187716-0bf6-45f4-8bb9-ff285f6b14bf', N'admin@domain.com', 0, N'ACgIeeBUdaJTRhQ2BgjpRjCMptTUTAxAZEqRk+GSX0Oo2shdwWGcYKibhEgaLy0B4Q==', N'b6ee05ed-0dc4-4640-a518-957d16ad37cb', NULL, 0, 0, NULL, 1, 0, N'admin@domain.com')

INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'69948b29-b512-45f0-a722-b3561130ee35', N'ManageCustomerInfo')

INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'7d187716-0bf6-45f4-8bb9-ff285f6b14bf', N'69948b29-b512-45f0-a722-b3561130ee35')
");
        }
        
        public override void Down()
        {
        }
    }
}
