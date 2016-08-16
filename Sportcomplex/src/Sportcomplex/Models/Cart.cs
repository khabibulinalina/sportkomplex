using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sportcomplex.Models
{
    public class Cart : BaseEntity
    {
        private List<CartLine> LineCollection = new List<CartLine>();

        public IReadOnlyList<CartLine> Lines { get { return LineCollection; } }

        public void AddItem(Service service, int quantity)
        {
            var line = LineCollection
                .FirstOrDefault(b => b.Service.Id == service.Id);

            if (line == null)
                LineCollection.Add(new CartLine { Service = service, Quantity = quantity });
            else
            {
                line.Quantity += quantity;
            }
        }
        public void RemoveLine(Service servic)
        {
            LineCollection.RemoveAll(l => l.Service.Id == servic.Id);
        }

        public void Clear()
        {
            LineCollection.Clear();
        }

        internal void Clear(Service service, int v)
        {
            throw new NotImplementedException();
        }
    }

    public class CartLine : BaseEntity
    {
        public Service Service { get; set; }
        public int Quantity { get; set; }
    }
}

