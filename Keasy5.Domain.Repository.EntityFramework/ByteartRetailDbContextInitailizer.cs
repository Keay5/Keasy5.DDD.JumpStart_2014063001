using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Keasy5.Domain.Repository.EntityFramework
{
    /// <summary>
    /// 表示由Byteart Retail专用的数据访问上下文初始化器。
    /// </summary>
    /// <remarks>
    /// 相关资料：
    /// http://www.codeguru.com/csharp/article.php/c19999/Understanding-Database-Initializers-in-Entity-Framework-Code-First.htm
    /// 
    /// 要使用EntityFramework仓储（比如：服务层），需要调用
    ///     ByteartRetailDbContextInitailizer.Initialize();  //EntityFramwork初始化
    /// 
    /// </remarks>
    public sealed class ByteartRetailDbContextInitailizer : DropCreateDatabaseIfModelChanges<ByteartRetailDbContext>
    {
        // 请在使用ByteartRetailDbContextInitializer作为数据库初始化器（Database Initializer）时，去除以下代码行
        // 的注释，以便在数据库重建时，相应的SQL脚本会被执行。对于已有数据库的情况，请直接注释掉以下代码行。

        //During the testing phase you often need to populate database tables with sample data. 
        //At times you also need to populate some application data at the time of database creation. 
        //To see the Seed() method in action, you need to use BlogContextSeedInitializer in the Main() method. 
        //Adding the following line of code will do that job:
        //Database.SetInitializer(new BlogContextSeedInitializer());

        //protected override void Seed(ByteartRetailDbContext context)
        //{
        //    context.Database.ExecuteSqlCommand("CREATE UNIQUE INDEX IDX_CUSTOMER_USERNAME ON Customers(UserName)");
        //    context.Database.ExecuteSqlCommand("CREATE UNIQUE INDEX IDX_CUSTOMER_EMAIL ON Customers(Email)");
        //    context.Database.ExecuteSqlCommand("CREATE UNIQUE INDEX IDX_LAPTOP_NAME ON Laptops(Name)");
        //    base.Seed(context);
        //}

        /// <summary>
        /// 执行对数据库的初始化操作。
        /// </summary>
        public static void Initialize()
        {
            //At times you may want to use an existing database with Code First. 
            //In such cases you may not want to execute any initialization logic at all. 
            //You can suppress the database initialization process altogether 
            //by passing null to SetInitializer() method.

            /*Creating a Custom Database Initializer
             *    In the preceding examples you used inbuilt database initializers. 
             * You can also create a custom database initializer by implementing the IDatabaseInitializer interface. 
             * You need to implement the InitializeDatabase() method of IDatabaseInitializer interface and write your own logic of database creation. 
             * The following code shows a sample implementation of the InitializeDatabase() method:

                public class BlogContextCustomInitializer : IDatabaseInitializer<BlogContext>
                {
                    public void InitializeDatabase(BlogContext context)
                    {
                        if (context.Database.Exists())
                        {
                            if (!context.Database.CompatibleWithModel(true))
                            {
                                context.Database.Delete();
                            }
                        }
                        context.Database.Create();
                        context.Database.ExecuteSqlCommand("CREATE TABLE GLOBAL_DATA([KEY] VARCHAR(50), [VALUE] VARCHAR(250))");
                    }
                }
             * 
             * The InitializeDatabase() method receives an instance of a content class. You can then use the Exists() method to determine whether a database is already present. T
             * he CompatibleWithModel() method tells you (true / false) whether the database schema is compatible with the model. If the database is not compatible you delete and recreate it using Delete() and Create() methods respectively. 
             * If no database exists then you create a new one using the Create() method. Notice how the code is using the ExecuteSqlCommand() method to create the GLOBAL_DATA table that is not part of the model. 
             * Though we don't use that table in our example it illustrates how custom initializers can be used to perform custom tasks.
             * Now, set the BlogContextCustomInitializer class as the initializer using the SetInitializer() method and run the application. You will find that in addition to model tables, the GLOBAL_DATA table is also created.
             */
            Database.SetInitializer<ByteartRetailDbContext>(null); //传null表示关闭初始化
           // Database.SetInitializer<ByteartRetailDbContext>(new ByteartRetailDbContextInitailizer()); //开启初始化
        }
    }
}
