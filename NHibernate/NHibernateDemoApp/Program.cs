using NHibernateDemoApp;


try
{
    
    using (var session = SessionHelper.CreateSession())
    {
        Console.WriteLine(session.IsConnected);
        using (var transaction = session.BeginTransaction())
        {
            bool insert = false;
            if(insert)
            {
                var student1 = new Student()
                {
                    FirstMidName = "Abdullah Bin",
                    LastName = "Rahmatullah"
                };

                session.Save(student1);
                Console.WriteLine(student1);
                transaction.Commit();
            }

            bool read = false;
            if(read)
            {
                var id = 2;
                var student = session.Query<Student>().FirstOrDefault(x => x.ID == id);
                Console.WriteLine(student.FirstMidName);
            }

            bool update = false;
            if (update)
            {
                var idToUpdate = 3;
                var student = session.Get<Student>(idToUpdate);
                student.FirstMidName = "Md. Faisal";
                student.LastName = "Mahmud";
                session.Update(student);
                transaction.Commit();
            }

            bool delete = false;
            if (delete)
            {
                var idToDelete = 4;
                var student = session.Get<Student>(idToDelete);
                session.Delete(student);
                transaction.Commit();
            }
           
            bool accountInsert = false;
            if (accountInsert)
            {
                var account1 = new Account()
                {
                    AccountNumber = "NT-DEV-skull-2",
                    Balance = 33528574
                };

                session.Save(account1);
                transaction.Commit();

            }

            bool transactionCheck = true;
            if (transactionCheck)
            {
                var idFrom = 2;
                var idTo = 1;
                var amountTransfer = 100;

                var accountFrom = session.Get<Account>(idFrom);
                var accountTo = session.Get<Account>(idTo);

                accountFrom.Balance += amountTransfer;
                accountTo.Balance -= amountTransfer;

                session.Update(accountFrom);
                session.Update(accountTo);
                transaction.Commit();

            }
        }
    }
}
catch (Exception ex)
{
    Console.WriteLine($"Error: {ex.Message}");
}

Console.ReadLine();

