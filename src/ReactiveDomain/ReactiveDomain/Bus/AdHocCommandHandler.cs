using System;
using System.Collections.Generic;
using System.Reactive;
using ReactiveDomain.Messaging;
using ReactiveDomain.Util;

namespace ReactiveDomain.Bus
{
    public class AdHocCommandHandler<T> : IHandleCommand<T> where T : Command
    {
        private readonly Func<T, bool> _handleCommand;
        private readonly bool _wrapExceptions;
        private Guid _currentCommand = Guid.Empty;


        public AdHocCommandHandler(
                        Func<T, bool> handleCommandCommand,
                        bool wrapExceptions = true)
        {
            Ensure.NotNull(handleCommandCommand, "handle");
            _handleCommand = handleCommandCommand;
            _wrapExceptions = wrapExceptions;
        }

        public CommandResponse Handle(T command)
        {
            bool passed;
            _currentCommand = command.MsgId;
            try
            {
                var tCmd = command as TokenCancellableCommand;
                if (tCmd?.IsCanceled ?? false)
                    return tCmd.Canceled();

                passed = _handleCommand(command);
            }
            catch (Exception ex)
            {
                if (_wrapExceptions)
                    return command.Fail(ex);
                throw;
            }
            return passed ? command.Succeed() : command.Fail();
        }
    }
}