INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'7cd92aa9-a5fd-4e3a-8856-fad854094b0b', N'User', N'USER', N'ea497425-5edc-4285-9524-3eb4c0a66157')
INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'9b2f3af6-26c5-4257-910e-12b0bc19bd5b', N'Manager', N'MANAGER', N'7f259aab-d202-4898-b1aa-16408624650b')
INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'ab6506b1-0fd5-4aec-8ad8-7812f1cf03c3', N'Admin', N'ADMIN', N'924cf9e1-b8f4-4f6c-aa92-b4c3368a7a59')
GO
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'0a86abb4-2940-4078-9f62-d379bc24b476', N'admin@test.com', N'ADMIN@TEST.COM', N'admin@test.com', N'ADMIN@TEST.COM', 0, N'AQAAAAEAACcQAAAAEIWGiVtjJEZ0Rx+XO4ws6u48C2xJc0iMZyRfRqeKLhS5r/2qkrbE/xuQE0aEl1V+Ow==', N'LBMBJTIRFWMTEYIIDHWQIMF7OAY45YI2', N'436add18-1d4e-4479-82a6-921accbb87d5', NULL, 0, 0, NULL, 1, 0)
GO
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'0a86abb4-2940-4078-9f62-d379bc24b476', N'ab6506b1-0fd5-4aec-8ad8-7812f1cf03c3')
GO
