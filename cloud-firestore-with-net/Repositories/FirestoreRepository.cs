using cloud_firestore_with_net.Models;
using Google.Cloud.Firestore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

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

        public T Add<T>(T model) where T : FirebaseDocument
        {
            try
            {
                CollectionReference collectionReference = firestoreDb.Collection(CollectionName);
                DocumentReference newDocument = collectionReference.AddAsync(model).GetAwaiter().GetResult();
                model.Id = newDocument.Id;
                return model;
            }
            catch
            {
                return null;
            }
        }

        public bool Update<T>(T model) where T : FirebaseDocument
        {
            try
            {
                DocumentReference getDocument = firestoreDb.Collection(CollectionName).Document(model.Id);
                getDocument.SetAsync(model, SetOptions.MergeAll).GetAwaiter().GetResult();
                return true;
            }
            catch 
            {
                return false;
            }
        }

        public bool Delete<T>(T model) where T : FirebaseDocument
        {
            try
            {
                DocumentReference getDocument = firestoreDb.Collection(CollectionName).Document(model.Id);
                getDocument.DeleteAsync().GetAwaiter().GetResult();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public T Get<T>(T model) where T : FirebaseDocument
        {
            try
            {
                DocumentReference getDocument = firestoreDb.Collection(CollectionName).Document(model.Id);
                DocumentSnapshot snapshot = getDocument.GetSnapshotAsync().GetAwaiter().GetResult();
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
            catch
            {
                return null;
            }
        }

        public List<T> GetAll<T>() where T : FirebaseDocument
        {
            List<T> list = new();
            try
            {
                Query query = firestoreDb.Collection(CollectionName);
                QuerySnapshot querySnapshot = query.GetSnapshotAsync().GetAwaiter().GetResult();
                foreach (DocumentSnapshot documentSnapshot in querySnapshot.Documents)
                {
                    if (documentSnapshot.Exists)
                    {
                        Dictionary<string, object> city = documentSnapshot.ToDictionary();
                        string json = JsonConvert.SerializeObject(city);
                        T newItem = JsonConvert.DeserializeObject<T>(json);
                        newItem.Id = documentSnapshot.Id;
                        list.Add(newItem);
                    }
                }
            }
            catch
            {
            }
            return list;
        }

        public List<T> QueryRecords<T>(Query query) where T : FirebaseDocument
        {
            QuerySnapshot querySnapshot = query.GetSnapshotAsync().GetAwaiter().GetResult();
            List<T> list = new();
            foreach (DocumentSnapshot documentSnapshot in querySnapshot.Documents)
            {
                if (documentSnapshot.Exists)
                {
                    Dictionary<string, object> city = documentSnapshot.ToDictionary();
                    string json = JsonConvert.SerializeObject(city);
                    T newItem = JsonConvert.DeserializeObject<T>(json);
                    newItem.Id = documentSnapshot.Id;
                    list.Add(newItem);
                }
            }
            return list;
        }
    }
}