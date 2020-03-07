﻿using Avalonia.Controls;
using ExPay.Core.Navigation;
using System;
using System.Collections.Generic;

namespace ExPay_Service.Core.Navigation
{
    public static class Navigator
    {
        public static List<INavigatorAction> PageActions = new List<INavigatorAction>();
        public static int PageIndex = -1;

        public static void AddAction(INavigatorAction navigatorAction)
        {
            navigatorAction.Parent = _parent;

            PageActions.Add(navigatorAction);
        }

        public static void Forward()
        {
            if (PageIndex < PageActions.Count - 1)
            {
                PageIndex++;

                var action = PageActions[PageIndex];

                if (action.CanInvoke())
                {
                    Logger.Info($"Invoking Action {action.GetType().Name}");
                    action.Invoke();
                }
                else
                {
                    Logger.Info($"Skipping Action {action.GetType().Name}");
                    Forward();
                }
            }
        }

        public static Window GetParent() => _parent;

        public static void Init(Window parent, ContentControl frame, Control defaultContent = null)
        {
            if (frame is null)
            {
                throw new ArgumentNullException(nameof(frame));
            }

            _frame = frame;

            if (defaultContent != null)
            {
                _frame.Content = defaultContent;
            }

            _parent = parent;

            Logger.Info($"Navigator initialized");
        }

        public static void Navigate(Control control)
        {
            _frame.Content = control;

            Logger.Info($"Page switched to {control}");
        }

        public static void SetResult(object result)
        {
            _parent.Tag = result;
            _parent.Close();
        }

        private static readonly NLog.Logger Logger = NLog.LogManager.GetCurrentClassLogger();
        private static ContentControl _frame;
        private static Window _parent;
    }
}