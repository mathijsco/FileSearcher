namespace FileSearcher.Model.Engine
{
    public enum CriterionWeight
    {
        /// <summary>
        /// Plain validation on variable
        /// </summary>
        None,
        /// <summary>
        /// Plain validation on variable with some advanced algorithms.
        /// </summary>
        Light,
        /// <summary>
        /// Validation on variable that is not resolved yet.
        /// </summary>
        Medium,
        /// <summary>
        /// Validation on very large variable that is not resolved yet.
        /// </summary>
        Heavy,
        /// <summary>
        /// Validation on a very large variable with complex calculations that you better not use.
        /// </summary>
        Extreme
    }
}
