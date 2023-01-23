using System;
using System.Collections.Generic;

public interface IMessageHistoryProvider
{
    public void GetMessageHistory(Action<List<string>> onGetMessageHistory);
}