using cloud_firestore_with_net.Models;

namespace cloud_firestore_with_net.Repositories
{
    public class PokemonRepository : IFirestoreRepository<Pokemon>
    {
        private readonly string CollectionName = "collection-name";
        private readonly FirestoreRepository firestoreRepository;

        public PokemonRepository()
        {
            firestoreRepository = new FirestoreRepository(CollectionName);
        }

        public Pokemon Get(Pokemon pokemon) => firestoreRepository.Get(pokemon);
    }
}