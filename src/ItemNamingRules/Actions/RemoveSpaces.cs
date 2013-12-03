using Sitecore.Rules;
using System.Text.RegularExpressions;

namespace Sitecore.Sharedsource.ItemNamingRules.Actions
{
    /// <summary>
    ///     Rules engine action to replace invalid characters in item names.
    /// </summary>
    /// <typeparam name="T">Type providing rule context.</typeparam>
    public class RemoveSpaces<T> : RenamingAction<T> where T : RuleContext
    {
        /// <summary>
        ///     Action implementation.
        /// </summary>
        /// <param name="ruleContext">The rule context.</param>
        public override void Apply(T ruleContext)
        {
            var newName = Regex.Replace(ruleContext.Item.Name, @"\s", "");
            if (ruleContext.Item.Name != newName)
            {
                RenameItem(ruleContext.Item, newName);
            }
        }
    }
}