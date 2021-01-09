using System;
using System.Linq;
using System.Collections.Generic;

namespace EFCoreDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create
            Patient patientOne = new Patient() {FirstName ="Kareem", LastName = "Dana"};

            using (var db = new AppDbContext())
            { // logged into the database
                if (db.Database.EnsureCreated()) 
                {
                    db.Add(patientOne);
                }                
                db.SaveChanges();
            } // log out or close the session to our database

            // Read
            // AppDbContext is the name of our class in DbContext.cs
            using (var db = new AppDbContext())
            {
                // db.Patients is the DbSet object in DbContext.cs. It is essentially a list of
                // all the patient records in our database that we can loop through
                foreach (Patient p in db.Patients)
                {
                    // Using the ToString() method in Patient Entity class
                    Console.WriteLine(p);
                    // Without ToString() we need:
                    //Console.WriteLine($"{p.PatientID} - {p.FirstName} {p.LastName}");
                }
            }

            // Update
            using (var db = new AppDbContext())
            {
                // STEP 1: Find the record you want to update
                // You can use .First() to find the first entry or .Find(primaryKey)
                // LINQ will give us more ways to retreive/find records in our database
                Patient patientToUpdate = db.Patients.First();

                // STEP 2: Change whatever property or properties you want to update
                patientToUpdate.FirstName = "Amjad";

                // STEP 3: Save the changes back to the database
                db.SaveChanges();
            } // Log out/close db session

            // Remove
            using (var db = new AppDbContext())
            {
               // Patient patientToRemove = db.Patients.Find(2);
                //db.Remove(patientToRemove);
                //db.SaveChanges();
            }

            List<Patient> patients = new List<Patient> {
                new Patient { FirstName = "Jeff", LastName = "Babb"},
                new Patient { FirstName = "Sean", LastName = "Humpherys"},
                new Patient { FirstName = "Walter", LastName = "Wendler"}
            };

            using (var db = new AppDbContext())
            {
                db.AddRange(patients);
                db.SaveChanges();
                foreach (Patient p in db.Patients)
                {
                    Console.WriteLine(p);
                }
            }
        }
    }
}