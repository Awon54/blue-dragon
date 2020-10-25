using blue_dragon.Data;
using System;

namespace blue_dragon.Models
{
    public class ActivityD
    {

        public static void ActivityDummyData(BlueDragonDbContext db)
        {
            V1.Activity fromDb = db.Activities.Find(1);

            if (fromDb == null)
            {
                // Create Dummy data if db is empty
                Console.WriteLine("Add New Activity: ");
                db.Activities.Add(new V1.Activity { DateTime = ConvertToDatetime("2020-09-08T16:34:23Z"), Description = "Bank Deposit", Amount = 500.00 , Status = "Completed" });
                db.Activities.Add(new V1.Activity { DateTime = ConvertToDatetime("2020-09-08T09:02:23Z"), Description = "Transfer to James", Amount = -20.00, Status = "Pending" });
                db.Activities.Add(new V1.Activity { DateTime = ConvertToDatetime("2020-09-07T21:52:23Z"), Description = "ATM withdrawal", Amount = -20.00, Status = "Completed" });
                db.Activities.Add(new V1.Activity { DateTime = ConvertToDatetime("2020-09-06T10:32:23Z"), Description = "Google Subscription", Amount = -15.00, Status = "Completed" });
                db.Activities.Add(new V1.Activity { DateTime = ConvertToDatetime("2020-09-06T07:33:23Z"), Description = "Apple Store", Amount = -2000.00, Status = "Cancelled" });
                db.Activities.Add(new V1.Activity { DateTime = ConvertToDatetime("2020-08-23T17:39:23Z"), Description = "Mini Mart", Amount = -23.76, Status = "Completed" });
                db.Activities.Add(new V1.Activity { DateTime = ConvertToDatetime("2020-08-16T21:06:23Z"), Description = "Mini Mart", Amount = -56.43, Status = "Completed" });
                db.Activities.Add(new V1.Activity { DateTime = ConvertToDatetime("2020-06-15T18:17:23Z"), Description = "Country Railways", Amount = -167.78, Status = "Completed" });
                db.Activities.Add(new V1.Activity { DateTime = ConvertToDatetime("2020-04-09T16:26:23Z"), Description = "Refund", Amount = 30.00, Status = "Completed" });
                db.Activities.Add(new V1.Activity { DateTime = ConvertToDatetime("2020-04-01T12:47:23Z"), Description = "Amazon Online", Amount = -30.00, Status = "Completed" });
                db.Activities.Add(new V1.Activity { DateTime = ConvertToDatetime("2020-03-30T23:53:23Z"), Description = "Bank Deposit", Amount = 500.00, Status = "Completed" });
                db.SaveChanges();

        }


    }

        private static DateTime ConvertToDatetime(String dateInString)
        {


            return DateTime.Parse(dateInString);
        }
    }
}
