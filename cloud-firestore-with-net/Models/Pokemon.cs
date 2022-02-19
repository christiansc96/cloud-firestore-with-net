using Google.Cloud.Firestore;

namespace cloud_firestore_with_net.Models
{
    [FirestoreData]
    public class Pokemon : FirebaseDocument
    {
        [FirestoreProperty]
        public string category { get; set; }

        [FirestoreProperty]
        public string image { get; set; }

        [FirestoreProperty]
        public string name { get; set; }
    }
}