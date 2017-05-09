﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using lltg._1688.rponey.cc.Model.Entity;
using RPoney;

namespace lltg._1688.rponey.cc.Dal
{
    public class T_ProductUserTokenDal : IIdentityDal<T_ProductUserTokenEntity>
    {
        public bool Add(T_ProductUserTokenEntity entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(long id)
        {
            throw new NotImplementedException();
        }

        public bool Exist(long id)
        {
            throw new NotImplementedException();
        }

        public IList<T_ProductUserTokenEntity> Get(T_ProductUserTokenEntity entity)
        {
            throw new NotImplementedException();
        }

        public T_ProductUserTokenEntity Get(long id)
        {
            throw new NotImplementedException();
        }

        public bool Update(T_ProductUserTokenEntity entity)
        {
            throw new NotImplementedException();
        }

        public bool Save(T_ProductUserTokenEntity model)
        {
            var description = "保存用户令牌";
            try
            {
                var sql = $@"
if(Exists(select 1 from T_ProductUserToken(nolock) where ResourceOwner=@ResourceOwner))
    begin 
        insert into dbo.[T_ProductUserToken] (AliId,MemberId,ResourceOwner,AccessToken,RefreshToken,ExpiresIn,RefreshTokenTimeout,UpdateTime)
        values(@AliId,@MemberId,@ResourceOwner,@AccessToken,@RefreshToken,@ExpiresIn,@RefreshTokenTimeout,@UpdateTime)
    end;
else
    begin 
        update T_ProductUserToken set
            AliId=@AliId,
            MemberId=@MemberId,
            AccessToken=@AccessToken,
            RefreshToken=@RefreshToken,
            ExpiresIn=@ExpiresIn,
            RefreshTokenTimeout=@RefreshTokenTimeout,
            UpdateTime=@UpdateTime
        where ResourceOwner=@ResourceOwner
    end;
";
                var para = new List<SqlParameter>
            {
                new SqlParameter("@AliId", model.AliId),
                new SqlParameter("@AccessToken", model.AccessToken),
                new SqlParameter("@MemberId", model.MemberId),
                new SqlParameter("@RefreshToken", model.RefreshToken),
                new SqlParameter("@ExpiresIn", model.ExpiresIn),
                new SqlParameter("@RefreshTokenTimeout", model.RefreshTokenTimeout),
                new SqlParameter("@UpdateTime", model.UpdateTime),
                new SqlParameter("@ResourceOwner", model.ResourceOwner)
            };
                RPoney.Log.LoggerManager.Debug(GetType().Name, $"{description}sql:{sql}");
                return Rponey.DbHelper.DataBaseManager.MainDb().ExecuteNonQuery(sql, para.ToArray()) > 0;
            }
            catch (Exception ex)
            {
                RPoney.Log.LoggerManager.Error(GetType().Name, $"{description}异常", ex);
                return false;
            }
        }
    }
}
