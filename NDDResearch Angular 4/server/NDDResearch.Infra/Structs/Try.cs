﻿using System;

namespace NDDResearch.Infra.Structs
{
    using static Helpers;

    /// <summary>
    /// 
    /// Essa classe tem o objetivo de fornecer um retorno mais expressivo dos resultados de um função
    /// Ao realizar uma chamada para um Object podemos ter como resultado: Exception, null ou Object
    /// 
    /// Ex 1: Try<Exception, Customer> t; 
    ///     Se IsFailure é True, temos uma instancia de uma Exception
    ///     Se IsSucess é True, temos uma instancia de um Customer
    ///     
    /// Ex 2: Try<Exception, Result> 
    ///     Para Success é necessário fazer o retorno de Result.Successful
    /// 
    /// </summary>
    /// <typeparam name="TFailure"></typeparam>
    /// <typeparam name="TSuccess"></typeparam>
    public struct Try<TFailure, TSuccess>
    {
        public TFailure Failure { get; internal set; }
        public TSuccess Result { get; internal set; }

        public bool IsFailure { get; }
        public bool IsSuccess => !IsFailure;

        public Option<TFailure> OptionalFailure => IsFailure ? Some(Failure) : None;

        public Option<TSuccess> OptionalSuccess => IsSuccess ? Some(Result) : None;

        internal Try(TFailure failure)
        {
            IsFailure = true;
            Failure = failure;
            Result = default(TSuccess);
        }

        internal Try(TSuccess success)
        {
            IsFailure = false;
            Failure = default(TFailure);
            Result = success;
        }

        public TResult Match<TResult>(
                Func<TFailure, TResult> failure,
                Func<TSuccess, TResult> success
            )
            => IsFailure ? failure(Failure) : success(Result);

        public Result Match(
                Action<TFailure> failure,
                Action<TSuccess> success
            )
            => Match(ToFunc(failure), ToFunc(success));


        public static implicit operator Try<TFailure, TSuccess>(TFailure failure)
            => new Try<TFailure, TSuccess>(failure);

        public static implicit operator Try<TFailure, TSuccess>(TSuccess success)
            => new Try<TFailure, TSuccess>(success);

        public static Try<TFailure, TSuccess> Of(TSuccess obj) => obj;
        public static Try<TFailure, TSuccess> Of(TFailure obj) => obj;

    }

    /// <summary>
    /// Struct utilizado quando não existir um objeto de retorno.
    /// </summary>
    public struct Result
    {
        public static Result Successful { get { return new Result(); } }
    }

    /// <summary>
    /// Helper para essa classe que auxilia na manipulação das chamadas
    /// </summary>
    public static partial class Helpers
    {
        private static readonly Result unit = new Result();
        public static Result Unit() => unit;

        public static Func<T, Result> ToFunc<T>(Action<T> action) => o =>
        {
            action(o);
            return Unit();
        };

        public static Func<Result> ToFunc(Action action) => () =>
        {
            action();
            return Unit();
        };
    }
}
