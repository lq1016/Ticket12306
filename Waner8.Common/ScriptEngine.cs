using System;
using System.Collections.Generic;

using System.Text;
using MSScriptControl;

namespace Waner8.Common
{
    /// <summary>
    /// 脚本类型
    /// </summary>
    public enum ScriptLanguage
    {
        /// <summary>
        /// JScript脚本语言
        /// </summary>
        JScript,
        /// <summary>
        /// VBscript脚本语言
        /// </summary>
        VBscript,
        /// <summary>
        /// JavaScript脚本语言
        /// </summary>
        JavaScript
    }
    /// <summary>
    /// 脚本运行错误代理
    /// </summary>
    public delegate void RunErrorHandler();
    /// <summary>
    /// 脚本运行超时代理
    /// </summary>
    public delegate void RunTimeoutHandler();
    /// <summary>
    /// ScriptEngine类
    /// </summary>
    public class ScriptEngine
    {
        private ScriptControl msc;
        //定义脚本运行错误事件
        public event RunErrorHandler RunError;
        //定义脚本运行超时事件
        public event RunTimeoutHandler RunTimeout;
        /// <summary>
        ///构造函数
        /// </summary>
        public ScriptEngine()
            : this(ScriptLanguage.VBscript)
        { }
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="language">脚本类型</param>
        public ScriptEngine(ScriptLanguage language)
        {
            this.msc = new ScriptControl();
            this.msc.UseSafeSubset = true;
            this.msc.Language = language.ToString();
            ((DScriptControlSource_Event)this.msc).Error += new DScriptControlSource_ErrorEventHandler(ScriptEngine_Error);
            ((DScriptControlSource_Event)this.msc).Timeout += new DScriptControlSource_TimeoutEventHandler(ScriptEngine_Timeout);
        }
        /// <summary>
        /// 运行Eval方法
        /// </summary>
        /// <param name="expression">表达式</param>
        /// <param name="codeBody">函数体</param>
        /// <returns>返回值object</returns>
        public object Eval(string expression, string codeBody)
        {
            msc.AddCode(codeBody);
            return msc.Eval(expression);
        }
        /// <summary>
        /// 运行Eval方法
        /// </summary>
        /// <param name="language">脚本语言</param>
        /// <param name="expression">表达式</param>
        /// <param name="codeBody">函数体</param>
        /// <returns>返回值object</returns>
        public object Eval(ScriptLanguage language, string expression, string codeBody)
        {
            if (this.Language != language)
                this.Language = language;
            return Eval(expression, codeBody);
        }
        /// <summary>
        /// 运行Run方法
        /// </summary>
        /// <param name="mainFunctionName">入口函数名称</param>
        /// <param name="parameters">参数</param>
        /// <param name="codeBody">函数体</param>
        /// <returns>返回值object</returns>
        public object Run(string mainFunctionName, object[] parameters, string codeBody)
        {
            this.msc.AddCode(codeBody);
            return msc.Run(mainFunctionName, parameters);
        }
        /// <summary>
        /// 运行Run方法
        /// </summary>
        /// <param name="language">脚本语言</param>
        /// <param name="mainFunctionName">入口函数名称</param>
        /// <param name="parameters">参数</param>
        /// <param name="codeBody">函数体</param>
        /// <returns>返回值object</returns>
        public object Run(ScriptLanguage language, string mainFunctionName, object[] parameters, string codeBody)
        {
            if (this.Language != language)
                this.Language = language;
            return Run(mainFunctionName, parameters, codeBody);
        }
        /// <summary>
        /// 放弃所有已经添加到 ScriptControl 中的 Script 代码和对象
        /// </summary>
        public void Reset()
        {
            this.msc.Reset();
        }
        /// <summary>
        /// 获取或设置脚本语言
        /// </summary>
        public ScriptLanguage Language
        {
            get { return (ScriptLanguage)Enum.Parse(typeof(ScriptLanguage), this.msc.Language, false); }
            set { this.msc.Language = value.ToString(); }
        }
        /// <summary>
        /// 获取或设置脚本执行时间，单位为毫秒
        /// </summary>
        public int Timeout
        {
            get { return 0; }
        }
        /// <summary>
        /// 设置是否显示用户界面元素
        /// </summary>
        public bool AllowUI
        {
            get { return this.msc.AllowUI; }
            set { this.msc.AllowUI = value; }
        }
        /// <summary>
        /// 宿主应用程序是否有保密性要求
        /// </summary>
        public bool UseSafeSubset
        {
            get { return this.msc.UseSafeSubset; }
            set { this.msc.UseSafeSubset = true; }
        }
        /// <summary>
        /// RunError事件激发
        /// </summary>
        private void OnError()
        {
            if (RunError != null)
                RunError();
        }
        /// <summary>
        /// OnTimeout事件激发
        /// </summary>
        private void OnTimeout()
        {
            if (RunTimeout != null)
                RunTimeout();
        }
        private void ScriptEngine_Error()
        {
            OnError();
        }
        private void ScriptEngine_Timeout()
        {
            OnTimeout();
        }
    }
}
