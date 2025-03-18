using cloud_firestore_with_net.Models;
using System.Collections.Generic;

namespace cloud_firestore_with_net.Repositories
{
    public class PokemonRepository : IFirestoreRepository<Pokemon>
    {
        private readonly string CollectionName = "{collection-name}";
        private readonly FirestoreRepository firestoreRepository;

        public PokemonRepository()
        {
            firestoreRepository = new FirestoreRepository(CollectionName);
        }

        public Pokemon Add(Pokemon pokemon) => firestoreRepository.Add(pokemon);
        public bool Delete(Pokemon pokemon) => firestoreRepository.Delete(pokemon);

        public Pokemon Get(Pokemon pokemon) => firestoreRepository.Get(pokemon);

        public List<Pokemon> GetAll() => firestoreRepository.GetAll<Pokemon>();

        public bool Update(Pokemon pokemon) => firestoreRepository.Update(pokemon);
    }
}