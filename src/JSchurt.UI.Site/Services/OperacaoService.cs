using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JSchurt.UI.Site.Services
{
    public class OperacaoService
    {

        public IOperacaoTransient Transient { get; }
        public IOperacaoScoped Scoped { get; }
        public IOperacaoSingleton Singleton { get; }
        public IOperacaoSingletonInstance SingletoneInstance { get; }

        public OperacaoService(IOperacaoTransient transient, IOperacaoScoped scoped, IOperacaoSingleton singleton, IOperacaoSingletonInstance singletoneInstance)
        {
            Transient = transient ?? throw new ArgumentNullException(nameof(transient));
            Scoped = scoped ?? throw new ArgumentNullException(nameof(scoped));
            Singleton = singleton ?? throw new ArgumentNullException(nameof(singleton));
            SingletoneInstance = singletoneInstance ?? throw new ArgumentNullException(nameof(singletoneInstance));
        }
    } //class

    public class Operacao : IOperacaoTransient,
        IOperacaoScoped,
        IOperacaoSingleton,
        IOperacaoSingletonInstance
    {

        public Guid OperacaoId { get; }

        public Operacao(Guid id)
        {
            OperacaoId = id;
        }

        public Operacao() : this(Guid.NewGuid())
        {

        }

    } //class

    public interface IOperacao
    { 
        Guid OperacaoId { get; }
    } //interface

    public interface IOperacaoTransient : IOperacao
    {
        
    } //interface

    public interface IOperacaoScoped : IOperacao
    {

    } //interface

    public interface IOperacaoSingleton: IOperacao
    {

    } //interface

    public interface IOperacaoSingletonInstance : IOperacao
    {

    } //interface

} //namespace
