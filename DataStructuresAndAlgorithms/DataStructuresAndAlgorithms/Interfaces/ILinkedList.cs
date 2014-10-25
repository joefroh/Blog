namespace DataStructuresAndAlgorithms
{
    public interface ILinkedList<T>
    {
        /// <summary>
        ///     Property that keeps track of how large the list is.
        /// </summary>
        int Length { get; }

        /// <summary>
        ///     Method that adds a given value to the list.
        /// </summary>
        /// <param name="value">The value to be added to the list.</param>
        void Add(T value);

        /// <summary>
        ///     Method that tries to remove a given value from the list. If the value isn't in the list, this method returns false.
        ///     This method returns the first matching value in the list.
        ///     If data repeats, subsequent values are still present in the list.
        /// </summary>
        /// <param name="value">The value to be removed from the list.</param>
        /// <returns>True if the value was found and removed. False otherwise.</returns>
        bool Remove(T value);

        /// <summary>
        ///     Removes a given indexed value from the list.
        /// </summary>
        /// <param name="index">The index position to be removed.</param>
        /// <returns>True if the index was in range and removed, false otherwise.</returns>
        bool RemoveIndex(int index);

        /// <summary>
        ///     Searches the DoublyLinkedList and returns the index of the value being searched for.
        /// </summary>
        /// <param name="value">The value being searched for.</param>
        /// <returns>The index of the value being searched for or -1 if the value is not found.</returns>
        int Find(T value);

        /// <summary>
        ///     Returns the value stored at a given index in the list.
        /// </summary>
        /// <param name="index">The index to be retrieved.</param>
        /// <returns>The value stored at a given index in the list.</returns>
        T GetValueAtIndex(int index);
    }
}