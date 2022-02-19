using cloud_firestore_with_net.Models;
using Google.Cloud.Firestore;
using System;

namespace cloud_firestore_with_net.Repositories
{
    public class FirestoreRepository
    {
        private readonly string CollectionName;
        public FirestoreDb firestoreDb;

        public FirestoreRepository(string CollectionName)
        {
            string filePath = "/Users/{Username}/Downloads/{file-name}.json";
            Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", filePath);
            firestoreDb = FirestoreDb.Create("{database-name}");
            this.CollectionName = CollectionName;
        }

        public T Get<T>(T record) where T : FirebaseDocument
        {
            DocumentReference docRef = firestoreDb.Collection(CollectionName).Document(record.Id);
            DocumentSnapshot snapshot = docRef.GetSnapshotAsync().GetAwaiter().GetResult();
            if (snapshot.Exists)
            {
                T usr = snapshot.ConvertTo<T>();
                usr.Id = snapshot.Id;
                return usr;
            }
            else
            {
                return null;
            }
        }
    }
}