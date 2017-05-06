﻿using System;

namespace Rponey.DbHelper.Transaction
{
    public interface ITransaction : IDisposable
    {
        /// <summary>
        /// 事务开始
        /// </summary>
        void BeginTransaction();
        /// <summary>
        /// 提交事务
        /// </summary>
        void CommitTransaction();
        T GetTransactionContext<T>();
        /// <summary>
        /// 回滚事务
        /// </summary>
        void RollbackTransaction();
    }
    public enum TransactionType
    {
        IDbHelper = 0,
    }
}
