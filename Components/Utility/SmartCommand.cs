using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MatrixBinder_Dotnet7.Components.Utility;

/// <summary>
/// Smarter way to handle ICommands
/// Determining the CanExecute is done with a lambda attached
/// CanExecute Sync is publicly available
/// </summary>
public class SmartCommand: ICommand
{
    #region Properties
    public event EventHandler CanExecuteChanged;

    protected Func<object,bool> predicate;
    protected Action<object> action;
    #endregion

    #region Constructor
    /// <summary>
    /// Creates a SmartCommand with both the predicate and action Attached
    /// </summary>
    /// <param name="predicate">Boolean lambda to determine the command's availability</param>
    /// <param name="action">Void lambda to perform and Action</param>
    public SmartCommand(Func<object,bool> predicate, Action<object> action)
    {
        this.predicate = predicate;
        this.action = action;
    }

    /// <summary>
    /// Creates a SmartCommand with only the Action attached
    ///
    /// It's predicate will always return true;
    /// </summary>
    /// <param name="action"></param>
    public SmartCommand(Action<object> action)
    {
        this.predicate = null;
        this.action = action;
    }
    #endregion

    #region Methods
    public bool CanExecute(object parameter)
    {
        if (predicate != null) 
        { 
            return true; 
        }
        return predicate(parameter);
    }

    public void Execute(object parameter)
    {
        action(parameter);
    }

    public void RaiseCanExecuteChanged()
    {
        CanExecuteChanged?.Invoke(this, EventArgs.Empty);
    }
    #endregion
}
