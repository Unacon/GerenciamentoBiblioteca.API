﻿namespace GerenciamentoBiblioteca.Core.Models
{
    public class ResultViewModel
    {
        public ResultViewModel(bool isSucess = true, string message = "")
        {
            IsSucess = isSucess;
            Message = message;
        }

        public bool IsSucess { get; private set; }
        public string Message { get; private set; }

        public static ResultViewModel Sucess() => new ResultViewModel();
        public static ResultViewModel Sucess(string message) => new ResultViewModel(true, message);
        public static ResultViewModel Error(string message) => new ResultViewModel(false, message);
    }

    public class ResultViewModel<T> : ResultViewModel
    {
        public ResultViewModel(T? data, bool isSucess = true, string message = "") : base(isSucess, message)
        {
            Data = data;
        }

        public T? Data { get; private set; }

        public static ResultViewModel<T> Sucess(T data) => new ResultViewModel<T>(data);
        public static ResultViewModel<T> Sucess(string message) => new ResultViewModel<T>(default, true, message);
        public static ResultViewModel<T> Error(string message) => new ResultViewModel<T>(default, false, message);
    }
}
