﻿using ReactiveDomain.Tests.Specifications;

namespace ReactiveDomain.Tests.Subscribers.QueuedSubscriber
{
    // ReSharper disable InconsistentNaming
    public abstract class when_using_queued_subscriber : CommandBusSpecification
    {
        protected TestQueuedSubscriber MessageSubscriber;

        protected override void Given()
        {
            MessageSubscriber = new TestQueuedSubscriber(Bus);
        }

    }
}
