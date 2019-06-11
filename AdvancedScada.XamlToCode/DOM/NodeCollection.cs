using System.Collections;
using System.Collections.Generic;
namespace AdvancedScada.XamlToCode.DOM
{
    public class NodeCollection<T> : IList<T>
    {

        private List<T> _Nodes;
        private readonly ObjectNode _ParentObject;
        private readonly MemberNode _ParentProperty;

        public NodeCollection(ObjectNode parentObject)
        {
            _ParentObject = parentObject;
        }

        public NodeCollection(MemberNode parentProperty)
        {
            _ParentProperty = parentProperty;
        }
        private List<T> Nodes
        {
            get
            {
                if (_Nodes == null)
                    _Nodes = new List<T>();
                return _Nodes;
            }
        }
        public int Count => Nodes.Count;

        #region IEnumerable<T> Members

        public IEnumerator<T> GetEnumerator()
        {
            return Nodes.GetEnumerator();
        }

        #endregion

        #region IEnumerable Members

        IEnumerator IEnumerable.GetEnumerator()
        {
            return Nodes.GetEnumerator();
        }

        #endregion


        private void SetParent(T node)
        {
            var itemNode = node as ItemNode;
            var propNode = node as MemberNode;

            if (itemNode != null)
                itemNode.ParentMemberNode = _ParentProperty;
            if (propNode != null)
                propNode.ParentObjectNode = _ParentObject;
        }
        private void SetParentToNull(T node)
        {
            var objNode = node as ObjectNode;
            var propNode = node as MemberNode;

            if (objNode != null)
                objNode.ParentMemberNode = null;
            if (propNode != null)
                propNode.ParentObjectNode = null;
        }
        #region IList<T> Members

        public void Add(T node)
        {
            Nodes.Add(node);
            SetParent(node);
        }
        public int IndexOf(T item)
        {
            return Nodes.IndexOf(item);
        }

        public void Insert(int index, T item)
        {
            Nodes.Insert(index, item);
            SetParent(item);
        }

        public void RemoveAt(int index)
        {
            SetParentToNull(Nodes[index]);
            Nodes.RemoveAt(index);
        }

        public T this[int index]
        {
            get => Nodes[index];
            set
            {
                Nodes[index] = value;
                SetParent(value);
            }
        }

        #endregion

        #region ICollection<T> Members

        public void Clear()
        {
            foreach (var node in Nodes)
                SetParentToNull(node);
            Nodes.Clear();
        }

        public bool Contains(T item)
        {
            return Nodes.Contains(item);
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            Nodes.CopyTo(array, arrayIndex);
            //TODO: should .Parent property be cleared on the copies?
        }

        public bool IsReadOnly => false;

        public bool Remove(T item)
        {
            SetParentToNull(item);
            return Nodes.Remove(item);
        }

        #endregion
    }
}
