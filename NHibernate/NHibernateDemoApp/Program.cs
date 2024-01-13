using NHibernateDemoApp;


try
{

    using (var session = SessionHelper.CreateSession())
    {
        Console.WriteLine(session.IsConnected);
        using (var transaction = session.BeginTransaction())
        {
            bool insert = false;
            if (insert)
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
            if (read)
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

            bool transactionCheck = false;
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

            bool insertParent = false;
            if (insertParent)
            {
                var parent = new Parent()
                {
                    ParentName = "Mr john"
                };

                var child1 = new Child() { ChildName = "Child1", Parent = parent };
                var child2 = new Child() { ChildName = "Child2", Parent = parent };

                parent.Children.Add(child1);
                parent.Children.Add(child2);

                session.Save(parent);
                transaction.Commit();

            }

            bool readParent = false;
            if (readParent)
            {
                var parentId = 6;
                var parent = session.Get<Parent>(parentId);

                if (parent != null)
                {
                    Console.WriteLine($"Parent Name: {parent.ParentName}");

                    foreach (var child in parent.Children)
                    {
                        Console.WriteLine($"Child Name: {child.ChildName}");
                    }
                }
            }

            bool updateParent = false;
            if (updateParent)
            {
                var parentIdToUpdate = 6;
                var parentToUpdate = session.Get<Parent>(parentIdToUpdate);

                if (parentToUpdate != null)
                {
                    parentToUpdate.ParentName = "ParentUI";
                    int i = 1;
                    // Update child names if needed
                    foreach (var child in parentToUpdate.Children)
                    {
                        child.ChildName = "childUI" + i++;
                    }

                    session.Update(parentToUpdate);
                    transaction.Commit();
                }
            }

            bool deleteParent = false;
            if (deleteParent)
            {
                var parentIdToDelete = 6;
                var parentToDelete = session.Get<Parent>(parentIdToDelete);

                if (parentToDelete != null)
                {
                    session.Delete(parentToDelete);
                    transaction.Commit();
                }
            }

            bool insertChild = false;
            if (insertChild)
            {
                var child = new Child()
                {
                    ChildName = "Mr. Zayed Khan",
                    Parent = session.Get<Parent>(7) // Set the parent reference
                };

                session.Save(child);
                transaction.Commit();
            }

            bool readChild = false;
            if (readChild)
            {
                var childId = 7;
                var child = session.Get<Child>(childId);

                if (child != null)
                {
                    Console.WriteLine($"Child Name: {child.ChildName}");
                    Console.WriteLine($"Parent Name: {child.Parent.ParentName}");
                }
            }

            bool updateChild = false;
            if (updateChild)
            {
                var childIdToUpdate = 7;
                var childToUpdate = session.Get<Child>(childIdToUpdate);

                if (childToUpdate != null)
                {
                    childToUpdate.ChildName = "Sakib Khan";
                    session.Update(childToUpdate);
                    transaction.Commit();
                }
            }

            bool deleteChild = false;
            if (deleteChild)
            {
                var childIdToDelete = 7;
                var childToDelete = session.Get<Child>(childIdToDelete);

                if (childToDelete != null)
                {
                    session.Delete(childToDelete);
                    transaction.Commit();
                }
            }






        }
    }
}
catch (Exception ex)
{
    Console.WriteLine($"Error: {ex.Message}");
}

Console.ReadLine();

