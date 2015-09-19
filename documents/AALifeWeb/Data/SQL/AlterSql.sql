alter table UserTable drop constraint DF__UserTable__Categ__0FEC5ADD
alter table UserTable alter column CategoryRate int not null 
alter table UserTable add constraint DF__UserTable__Categ__0FEC5ADD default 0 for CategoryRate

alter table UserCategoryTable drop constraint DF__UserCateg__Categ__0A338187
alter table UserCategoryTable alter column CategoryTypePrice decimal(10, 0) not null 
alter table UserCategoryTable add constraint DF__UserCateg__Categ__0A338187 default 0 for CategoryTypePrice

alter table UserTable add MoneyStart decimal(10, 3) default 0 null
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'钱包初始' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UserTable', @level2type=N'COLUMN',@level2name=N'MoneyStart'
GO

alter table CardTable add MoneyStart decimal(10, 3) default 0 null
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'钱包初始' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CardTable', @level2type=N'COLUMN',@level2name=N'MoneyStart'
GO

alter table UserTable add IsUpdate tinyint default 0 null
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否升级' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UserTable', @level2type=N'COLUMN',@level2name=N'IsUpdate'
GO

update UserTable set IsUpdate=0
