using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStoreApi.Exceptions
{
    public class BookDoesNotExistException : Exception
    {
        private int id { get; set; }

        public BookDoesNotExistException(int id) : base($"Livro com id {id} nao encontrado.") 
        { 
            this.id = id;
        }
    }
}