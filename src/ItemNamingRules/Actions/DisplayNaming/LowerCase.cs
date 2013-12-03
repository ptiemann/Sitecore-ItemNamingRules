namespace Sitecore.Sharedsource.ItemNamingRules.Actions.DisplayNaming
{
    /// <summary>
    /// Rules engine action to lowercase item DisplayName.
    /// </summary>
    /// <typeparam name="T">Type providing rule context.</typeparam>
    public class Lowercase<T> : ChangeDisplayNameAction<T>
        where T : Sitecore.Rules.RuleContext
    {
        /// <summary>
        /// Action implementation.
        /// </summary>
        /// <param name="ruleContext">The rule context.</param>
        public override void Apply(T ruleContext)
        {
            string newName = ruleContext.Item.DisplayName.ToLower();

            if (ruleContext.Item.DisplayName != newName)
            {
                this.ChangeDisplayName(ruleContext.Item, newName);
            }
        }
    }
}