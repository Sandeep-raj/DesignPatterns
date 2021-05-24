/*
 * ATTENTION: The "eval" devtool has been used (maybe by default in mode: "development").
 * This devtool is neither made for production nor for readable output files.
 * It uses "eval()" calls to create a separate source file in the browser devtools.
 * If you are trying to read the output file, select a different devtool (https://webpack.js.org/configuration/devtool/)
 * or disable the default devtool with "devtool: false".
 * If you are looking for production-ready output files, see mode: "production" (https://webpack.js.org/configuration/mode/).
 */
/******/ (() => { // webpackBootstrap
/******/ 	var __webpack_modules__ = ({

/***/ "./controller.js":
/*!***********************!*\
  !*** ./controller.js ***!
  \***********************/
/***/ ((module) => {

eval("function _classCallCheck(instance, Constructor) { if (!(instance instanceof Constructor)) { throw new TypeError(\"Cannot call a class as a function\"); } }\n\nfunction _defineProperty(obj, key, value) { if (key in obj) { Object.defineProperty(obj, key, { value: value, enumerable: true, configurable: true, writable: true }); } else { obj[key] = value; } return obj; }\n\nvar Controller = function Controller(model, view) {\n  var _this = this;\n\n  _classCallCheck(this, Controller);\n\n  _defineProperty(this, \"onTodoListChanged\", function (todos) {\n    _this.view.displayTodos(todos);\n  });\n\n  _defineProperty(this, \"handleAddTodo\", function (todoText) {\n    _this.model.addTodo(todoText);\n  });\n\n  _defineProperty(this, \"handleEditTodo\", function (id, updatedText) {\n    _this.model.editTodo(id, updatedText);\n  });\n\n  _defineProperty(this, \"handleDeleteTodo\", function (id) {\n    _this.model.deleteTodo(id);\n  });\n\n  _defineProperty(this, \"handleToggleTodo\", function (id) {\n    _this.model.toggleTodo(id);\n  });\n\n  this.model = model;\n  this.view = view; // Explicit this binding\n\n  this.model.bindTodoListChanged(this.onTodoListChanged);\n  this.view.bindAddTodo(this.handleAddTodo);\n  this.view.bindEditTodo(this.handleEditTodo);\n  this.view.bindDeleteTodo(this.handleDeleteTodo);\n  this.view.bindToggleTodo(this.handleToggleTodo); // Display initial todos\n\n  this.onTodoListChanged(this.model.todos);\n};\n\nmodule.exports = Controller;\n\n//# sourceURL=webpack://javascript/./controller.js?");

/***/ }),

/***/ "./model.js":
/*!******************!*\
  !*** ./model.js ***!
  \******************/
/***/ ((module) => {

eval("function _classCallCheck(instance, Constructor) { if (!(instance instanceof Constructor)) { throw new TypeError(\"Cannot call a class as a function\"); } }\n\nfunction _defineProperties(target, props) { for (var i = 0; i < props.length; i++) { var descriptor = props[i]; descriptor.enumerable = descriptor.enumerable || false; descriptor.configurable = true; if (\"value\" in descriptor) descriptor.writable = true; Object.defineProperty(target, descriptor.key, descriptor); } }\n\nfunction _createClass(Constructor, protoProps, staticProps) { if (protoProps) _defineProperties(Constructor.prototype, protoProps); if (staticProps) _defineProperties(Constructor, staticProps); return Constructor; }\n\nvar Model = /*#__PURE__*/function () {\n  function Model() {\n    _classCallCheck(this, Model);\n\n    this.todos = JSON.parse(localStorage.getItem(\"todos\")) || [];\n  }\n\n  _createClass(Model, [{\n    key: \"bindTodoListChanged\",\n    value: function bindTodoListChanged(callback) {\n      this.onTodoListChanged = callback;\n    }\n  }, {\n    key: \"_commit\",\n    value: function _commit(todos) {\n      this.onTodoListChanged(todos);\n      localStorage.setItem(\"todos\", JSON.stringify(todos));\n    }\n  }, {\n    key: \"addTodo\",\n    value: function addTodo(todoText) {\n      var todo = {\n        id: this.todos.length > 0 ? this.todos[this.todos.length - 1].id + 1 : 1,\n        text: todoText,\n        complete: false\n      };\n      this.todos.push(todo);\n\n      this._commit(this.todos);\n    }\n  }, {\n    key: \"editTodo\",\n    value: function editTodo(id, updateText) {\n      this.todos = this.todos.map(function (todo) {\n        return todo.id === id ? {\n          id: todo.id,\n          text: updateText,\n          complete: todo.complete\n        } : todo;\n      });\n\n      this._commit(this.todos);\n    }\n  }, {\n    key: \"deleteTodo\",\n    value: function deleteTodo(id) {\n      this.todos = this.todos.filter(function (todo) {\n        return todo.id !== id;\n      });\n\n      this._commit(this.todos);\n    }\n  }, {\n    key: \"toggleTodo\",\n    value: function toggleTodo(id) {\n      this.todos = this.todos.map(function (todo) {\n        return todo.id === id ? {\n          id: todo.id,\n          text: todo.text,\n          complete: !todo.complete\n        } : todo;\n      });\n\n      this._commit(this.todos);\n    }\n  }]);\n\n  return Model;\n}();\n\nmodule.exports = Model;\n\n//# sourceURL=webpack://javascript/./model.js?");

/***/ }),

/***/ "./script.js":
/*!*******************!*\
  !*** ./script.js ***!
  \*******************/
/***/ ((__unused_webpack_module, __unused_webpack_exports, __webpack_require__) => {

eval("var Model = __webpack_require__(/*! ./model */ \"./model.js\");\n\nvar View = __webpack_require__(/*! ./view */ \"./view.js\");\n\nvar Controller = __webpack_require__(/*! ./controller */ \"./controller.js\");\n\n__webpack_require__(/*! ./style.css */ \"./style.css\");\n\nvar app = new Controller(new Model(), new View());\n\n//# sourceURL=webpack://javascript/./script.js?");

/***/ }),

/***/ "./view.js":
/*!*****************!*\
  !*** ./view.js ***!
  \*****************/
/***/ ((module) => {

eval("function _classCallCheck(instance, Constructor) { if (!(instance instanceof Constructor)) { throw new TypeError(\"Cannot call a class as a function\"); } }\n\nfunction _defineProperties(target, props) { for (var i = 0; i < props.length; i++) { var descriptor = props[i]; descriptor.enumerable = descriptor.enumerable || false; descriptor.configurable = true; if (\"value\" in descriptor) descriptor.writable = true; Object.defineProperty(target, descriptor.key, descriptor); } }\n\nfunction _createClass(Constructor, protoProps, staticProps) { if (protoProps) _defineProperties(Constructor.prototype, protoProps); if (staticProps) _defineProperties(Constructor, staticProps); return Constructor; }\n\nvar View = /*#__PURE__*/function () {\n  function View() {\n    _classCallCheck(this, View);\n\n    this.app = this.getElement(\"#root\");\n    this.form = this.createElement(\"form\");\n    this.input = this.createElement(\"input\");\n    this.input.type = \"text\";\n    this.input.placeholder = \"Add todo\";\n    this.input.name = \"todo\";\n    this.submitButton = this.createElement(\"button\");\n    this.submitButton.textContent = \"Submit\";\n    this.form.append(this.input, this.submitButton);\n    this.title = this.createElement(\"h1\");\n    this.title.textContent = \"Todos\";\n    this.todoList = this.createElement(\"ul\", \"todo-list\");\n    this.app.append(this.title, this.form, this.todoList);\n  }\n\n  _createClass(View, [{\n    key: \"createElement\",\n    value: function createElement(tag, className) {\n      var element = document.createElement(tag);\n      if (className) element.classList.add(className);\n      return element;\n    }\n  }, {\n    key: \"getElement\",\n    value: function getElement(selector) {\n      var element = document.querySelector(selector);\n      return element;\n    }\n  }, {\n    key: \"_todoText\",\n    get: function get() {\n      return this.input.value;\n    }\n  }, {\n    key: \"_resetInput\",\n    value: function _resetInput() {\n      this.input.value = \"\";\n    }\n  }, {\n    key: \"bindAddTodo\",\n    value: function bindAddTodo(handler) {\n      var _this = this;\n\n      this.form.addEventListener(\"submit\", function (event) {\n        event.preventDefault();\n\n        if (_this._todoText) {\n          console.log(_this._todoText);\n          handler(_this._todoText);\n\n          _this._resetInput();\n        }\n      });\n    }\n  }, {\n    key: \"bindDeleteTodo\",\n    value: function bindDeleteTodo(handler) {\n      this.todoList.addEventListener(\"click\", function (event) {\n        if (event.target.className === \"delete\") {\n          var id = parseInt(event.target.parentElement.id);\n          handler(id);\n        }\n      });\n    }\n  }, {\n    key: \"bindEditTodo\",\n    value: function bindEditTodo(handler) {\n      var _this2 = this;\n\n      this.todoList.addEventListener(\"focusout\", function (event) {\n        if (_this2._temporaryTodoText) {\n          var id = parseInt(event.target.parentElement.id);\n          handler(id, _this2._temporaryTodoText);\n          _this2._temporaryTodoText = \"\";\n        }\n      });\n    }\n  }, {\n    key: \"bindToggleTodo\",\n    value: function bindToggleTodo(handler) {\n      this.todoList.addEventListener(\"change\", function (event) {\n        if (event.target.type === \"checkbox\") {\n          var id = parseInt(event.target.parentElement.id);\n          handler(id);\n        }\n      });\n    }\n  }, {\n    key: \"displayTodos\",\n    value: function displayTodos(todos) {\n      var _this3 = this;\n\n      // Delete all nodes\n      while (this.todoList.firstChild) {\n        this.todoList.removeChild(this.todoList.firstChild);\n      } // Show default message\n\n\n      if (todos.length === 0) {\n        var p = this.createElement(\"p\");\n        p.textContent = \"Nothing to do! Add a task?\";\n        this.todoList.append(p);\n      } else {\n        // Create nodes\n        todos.forEach(function (todo) {\n          var li = _this3.createElement(\"li\");\n\n          li.id = todo.id;\n\n          var checkbox = _this3.createElement(\"input\");\n\n          checkbox.type = \"checkbox\";\n          checkbox.checked = todo.complete;\n\n          var span = _this3.createElement(\"span\");\n\n          span.contentEditable = true;\n          span.classList.add(\"editable\");\n\n          if (todo.complete) {\n            var strike = _this3.createElement(\"s\");\n\n            strike.textContent = todo.text;\n            span.append(strike);\n          } else {\n            span.textContent = todo.text;\n          }\n\n          var deleteButton = _this3.createElement(\"button\", \"delete\");\n\n          deleteButton.textContent = \"Delete\";\n          li.append(checkbox, span, deleteButton); // Append nodes\n\n          _this3.todoList.append(li);\n        });\n      }\n    }\n  }, {\n    key: \"_initLocalListeners\",\n    value: function _initLocalListeners() {\n      var _this4 = this;\n\n      this.todoList.addEventListener(\"input\", function (event) {\n        if (event.target.className === \"editable\") {\n          _this4._temporaryTodoText = event.target.innerText;\n        }\n      });\n    }\n  }]);\n\n  return View;\n}();\n\nmodule.exports = View;\n\n//# sourceURL=webpack://javascript/./view.js?");

/***/ }),

/***/ "./node_modules/css-loader/dist/cjs.js!./style.css":
/*!*********************************************************!*\
  !*** ./node_modules/css-loader/dist/cjs.js!./style.css ***!
  \*********************************************************/
/***/ ((module, __webpack_exports__, __webpack_require__) => {

"use strict";
eval("__webpack_require__.r(__webpack_exports__);\n/* harmony export */ __webpack_require__.d(__webpack_exports__, {\n/* harmony export */   \"default\": () => (__WEBPACK_DEFAULT_EXPORT__)\n/* harmony export */ });\n/* harmony import */ var _node_modules_css_loader_dist_runtime_api_js__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! ./node_modules/css-loader/dist/runtime/api.js */ \"./node_modules/css-loader/dist/runtime/api.js\");\n/* harmony import */ var _node_modules_css_loader_dist_runtime_api_js__WEBPACK_IMPORTED_MODULE_0___default = /*#__PURE__*/__webpack_require__.n(_node_modules_css_loader_dist_runtime_api_js__WEBPACK_IMPORTED_MODULE_0__);\n// Imports\n\nvar ___CSS_LOADER_EXPORT___ = _node_modules_css_loader_dist_runtime_api_js__WEBPACK_IMPORTED_MODULE_0___default()(function(i){return i[1]});\n// Module\n___CSS_LOADER_EXPORT___.push([module.id, \"*,\\r\\n*::before,\\r\\n*::after {\\r\\n  box-sizing: border-box;\\r\\n}\\r\\n\\r\\nhtml {\\r\\n  font-family: sans-serif;\\r\\n  font-size: 1rem;\\r\\n  color: #444;\\r\\n}\\r\\n\\r\\n#root {\\r\\n  max-width: 450px;\\r\\n  margin: 2rem auto;\\r\\n  padding: 0 1rem;\\r\\n}\\r\\n\\r\\nform {\\r\\n  display: flex;\\r\\n  margin-bottom: 2rem;\\r\\n}\\r\\n\\r\\n[type=\\\"text\\\"],\\r\\nbutton {\\r\\n  display: inline-block;\\r\\n  -webkit-appearance: none;\\r\\n  padding: 0.5rem 1rem;\\r\\n  font-size: 1rem;\\r\\n  border: 2px solid #ccc;\\r\\n  border-radius: 4px;\\r\\n}\\r\\n\\r\\nbutton {\\r\\n  cursor: pointer;\\r\\n  background: #007bff;\\r\\n  color: white;\\r\\n  border: 2px solid #007bff;\\r\\n  margin: 0 0.5rem;\\r\\n}\\r\\n\\r\\n[type=\\\"text\\\"] {\\r\\n  width: 100%;\\r\\n}\\r\\n\\r\\n[type=\\\"text\\\"]:active,\\r\\n[type=\\\"text\\\"]:focus {\\r\\n  outline: 0;\\r\\n  border: 2px solid #007bff;\\r\\n}\\r\\n\\r\\n[type=\\\"checkbox\\\"] {\\r\\n  margin-right: 1rem;\\r\\n  font-size: 2rem;\\r\\n}\\r\\n\\r\\nh1 {\\r\\n  color: #222;\\r\\n}\\r\\n\\r\\nul {\\r\\n  padding: 0;\\r\\n}\\r\\n\\r\\nli {\\r\\n  display: flex;\\r\\n  align-items: center;\\r\\n  padding: 1rem;\\r\\n  margin-bottom: 1rem;\\r\\n  background: #f4f4f4;\\r\\n  border-radius: 4px;\\r\\n}\\r\\n\\r\\nli span {\\r\\n  display: inline-block;\\r\\n  padding: 0.5rem;\\r\\n  width: 250px;\\r\\n  border-radius: 4px;\\r\\n  border: 2px solid transparent;\\r\\n}\\r\\n\\r\\nli span:hover {\\r\\n  background: rgba(179, 215, 255, 0.52);\\r\\n}\\r\\n\\r\\nli span:focus {\\r\\n  outline: 0;\\r\\n  border: 2px solid #007bff;\\r\\n  background: rgba(179, 207, 255, 0.52);\\r\\n}\\r\\n\", \"\"]);\n// Exports\n/* harmony default export */ const __WEBPACK_DEFAULT_EXPORT__ = (___CSS_LOADER_EXPORT___);\n\n\n//# sourceURL=webpack://javascript/./style.css?./node_modules/css-loader/dist/cjs.js");

/***/ }),

/***/ "./node_modules/css-loader/dist/runtime/api.js":
/*!*****************************************************!*\
  !*** ./node_modules/css-loader/dist/runtime/api.js ***!
  \*****************************************************/
/***/ ((module) => {

"use strict";
eval("\n\n/*\n  MIT License http://www.opensource.org/licenses/mit-license.php\n  Author Tobias Koppers @sokra\n*/\n// css base code, injected by the css-loader\n// eslint-disable-next-line func-names\nmodule.exports = function (cssWithMappingToString) {\n  var list = []; // return the list of modules as css string\n\n  list.toString = function toString() {\n    return this.map(function (item) {\n      var content = cssWithMappingToString(item);\n\n      if (item[2]) {\n        return \"@media \".concat(item[2], \" {\").concat(content, \"}\");\n      }\n\n      return content;\n    }).join(\"\");\n  }; // import a list of modules into the list\n  // eslint-disable-next-line func-names\n\n\n  list.i = function (modules, mediaQuery, dedupe) {\n    if (typeof modules === \"string\") {\n      // eslint-disable-next-line no-param-reassign\n      modules = [[null, modules, \"\"]];\n    }\n\n    var alreadyImportedModules = {};\n\n    if (dedupe) {\n      for (var i = 0; i < this.length; i++) {\n        // eslint-disable-next-line prefer-destructuring\n        var id = this[i][0];\n\n        if (id != null) {\n          alreadyImportedModules[id] = true;\n        }\n      }\n    }\n\n    for (var _i = 0; _i < modules.length; _i++) {\n      var item = [].concat(modules[_i]);\n\n      if (dedupe && alreadyImportedModules[item[0]]) {\n        // eslint-disable-next-line no-continue\n        continue;\n      }\n\n      if (mediaQuery) {\n        if (!item[2]) {\n          item[2] = mediaQuery;\n        } else {\n          item[2] = \"\".concat(mediaQuery, \" and \").concat(item[2]);\n        }\n      }\n\n      list.push(item);\n    }\n  };\n\n  return list;\n};\n\n//# sourceURL=webpack://javascript/./node_modules/css-loader/dist/runtime/api.js?");

/***/ }),

/***/ "./style.css":
/*!*******************!*\
  !*** ./style.css ***!
  \*******************/
/***/ ((__unused_webpack_module, __webpack_exports__, __webpack_require__) => {

"use strict";
eval("__webpack_require__.r(__webpack_exports__);\n/* harmony export */ __webpack_require__.d(__webpack_exports__, {\n/* harmony export */   \"default\": () => (__WEBPACK_DEFAULT_EXPORT__)\n/* harmony export */ });\n/* harmony import */ var _node_modules_style_loader_dist_runtime_injectStylesIntoStyleTag_js__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! !./node_modules/style-loader/dist/runtime/injectStylesIntoStyleTag.js */ \"./node_modules/style-loader/dist/runtime/injectStylesIntoStyleTag.js\");\n/* harmony import */ var _node_modules_style_loader_dist_runtime_injectStylesIntoStyleTag_js__WEBPACK_IMPORTED_MODULE_0___default = /*#__PURE__*/__webpack_require__.n(_node_modules_style_loader_dist_runtime_injectStylesIntoStyleTag_js__WEBPACK_IMPORTED_MODULE_0__);\n/* harmony import */ var _node_modules_css_loader_dist_cjs_js_style_css__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! !!./node_modules/css-loader/dist/cjs.js!./style.css */ \"./node_modules/css-loader/dist/cjs.js!./style.css\");\n\n            \n\nvar options = {};\n\noptions.insert = \"head\";\noptions.singleton = false;\n\nvar update = _node_modules_style_loader_dist_runtime_injectStylesIntoStyleTag_js__WEBPACK_IMPORTED_MODULE_0___default()(_node_modules_css_loader_dist_cjs_js_style_css__WEBPACK_IMPORTED_MODULE_1__.default, options);\n\n\n\n/* harmony default export */ const __WEBPACK_DEFAULT_EXPORT__ = (_node_modules_css_loader_dist_cjs_js_style_css__WEBPACK_IMPORTED_MODULE_1__.default.locals || {});\n\n//# sourceURL=webpack://javascript/./style.css?");

/***/ }),

/***/ "./node_modules/style-loader/dist/runtime/injectStylesIntoStyleTag.js":
/*!****************************************************************************!*\
  !*** ./node_modules/style-loader/dist/runtime/injectStylesIntoStyleTag.js ***!
  \****************************************************************************/
/***/ ((module, __unused_webpack_exports, __webpack_require__) => {

"use strict";
eval("\n\nvar isOldIE = function isOldIE() {\n  var memo;\n  return function memorize() {\n    if (typeof memo === 'undefined') {\n      // Test for IE <= 9 as proposed by Browserhacks\n      // @see http://browserhacks.com/#hack-e71d8692f65334173fee715c222cb805\n      // Tests for existence of standard globals is to allow style-loader\n      // to operate correctly into non-standard environments\n      // @see https://github.com/webpack-contrib/style-loader/issues/177\n      memo = Boolean(window && document && document.all && !window.atob);\n    }\n\n    return memo;\n  };\n}();\n\nvar getTarget = function getTarget() {\n  var memo = {};\n  return function memorize(target) {\n    if (typeof memo[target] === 'undefined') {\n      var styleTarget = document.querySelector(target); // Special case to return head of iframe instead of iframe itself\n\n      if (window.HTMLIFrameElement && styleTarget instanceof window.HTMLIFrameElement) {\n        try {\n          // This will throw an exception if access to iframe is blocked\n          // due to cross-origin restrictions\n          styleTarget = styleTarget.contentDocument.head;\n        } catch (e) {\n          // istanbul ignore next\n          styleTarget = null;\n        }\n      }\n\n      memo[target] = styleTarget;\n    }\n\n    return memo[target];\n  };\n}();\n\nvar stylesInDom = [];\n\nfunction getIndexByIdentifier(identifier) {\n  var result = -1;\n\n  for (var i = 0; i < stylesInDom.length; i++) {\n    if (stylesInDom[i].identifier === identifier) {\n      result = i;\n      break;\n    }\n  }\n\n  return result;\n}\n\nfunction modulesToDom(list, options) {\n  var idCountMap = {};\n  var identifiers = [];\n\n  for (var i = 0; i < list.length; i++) {\n    var item = list[i];\n    var id = options.base ? item[0] + options.base : item[0];\n    var count = idCountMap[id] || 0;\n    var identifier = \"\".concat(id, \" \").concat(count);\n    idCountMap[id] = count + 1;\n    var index = getIndexByIdentifier(identifier);\n    var obj = {\n      css: item[1],\n      media: item[2],\n      sourceMap: item[3]\n    };\n\n    if (index !== -1) {\n      stylesInDom[index].references++;\n      stylesInDom[index].updater(obj);\n    } else {\n      stylesInDom.push({\n        identifier: identifier,\n        updater: addStyle(obj, options),\n        references: 1\n      });\n    }\n\n    identifiers.push(identifier);\n  }\n\n  return identifiers;\n}\n\nfunction insertStyleElement(options) {\n  var style = document.createElement('style');\n  var attributes = options.attributes || {};\n\n  if (typeof attributes.nonce === 'undefined') {\n    var nonce =  true ? __webpack_require__.nc : 0;\n\n    if (nonce) {\n      attributes.nonce = nonce;\n    }\n  }\n\n  Object.keys(attributes).forEach(function (key) {\n    style.setAttribute(key, attributes[key]);\n  });\n\n  if (typeof options.insert === 'function') {\n    options.insert(style);\n  } else {\n    var target = getTarget(options.insert || 'head');\n\n    if (!target) {\n      throw new Error(\"Couldn't find a style target. This probably means that the value for the 'insert' parameter is invalid.\");\n    }\n\n    target.appendChild(style);\n  }\n\n  return style;\n}\n\nfunction removeStyleElement(style) {\n  // istanbul ignore if\n  if (style.parentNode === null) {\n    return false;\n  }\n\n  style.parentNode.removeChild(style);\n}\n/* istanbul ignore next  */\n\n\nvar replaceText = function replaceText() {\n  var textStore = [];\n  return function replace(index, replacement) {\n    textStore[index] = replacement;\n    return textStore.filter(Boolean).join('\\n');\n  };\n}();\n\nfunction applyToSingletonTag(style, index, remove, obj) {\n  var css = remove ? '' : obj.media ? \"@media \".concat(obj.media, \" {\").concat(obj.css, \"}\") : obj.css; // For old IE\n\n  /* istanbul ignore if  */\n\n  if (style.styleSheet) {\n    style.styleSheet.cssText = replaceText(index, css);\n  } else {\n    var cssNode = document.createTextNode(css);\n    var childNodes = style.childNodes;\n\n    if (childNodes[index]) {\n      style.removeChild(childNodes[index]);\n    }\n\n    if (childNodes.length) {\n      style.insertBefore(cssNode, childNodes[index]);\n    } else {\n      style.appendChild(cssNode);\n    }\n  }\n}\n\nfunction applyToTag(style, options, obj) {\n  var css = obj.css;\n  var media = obj.media;\n  var sourceMap = obj.sourceMap;\n\n  if (media) {\n    style.setAttribute('media', media);\n  } else {\n    style.removeAttribute('media');\n  }\n\n  if (sourceMap && typeof btoa !== 'undefined') {\n    css += \"\\n/*# sourceMappingURL=data:application/json;base64,\".concat(btoa(unescape(encodeURIComponent(JSON.stringify(sourceMap)))), \" */\");\n  } // For old IE\n\n  /* istanbul ignore if  */\n\n\n  if (style.styleSheet) {\n    style.styleSheet.cssText = css;\n  } else {\n    while (style.firstChild) {\n      style.removeChild(style.firstChild);\n    }\n\n    style.appendChild(document.createTextNode(css));\n  }\n}\n\nvar singleton = null;\nvar singletonCounter = 0;\n\nfunction addStyle(obj, options) {\n  var style;\n  var update;\n  var remove;\n\n  if (options.singleton) {\n    var styleIndex = singletonCounter++;\n    style = singleton || (singleton = insertStyleElement(options));\n    update = applyToSingletonTag.bind(null, style, styleIndex, false);\n    remove = applyToSingletonTag.bind(null, style, styleIndex, true);\n  } else {\n    style = insertStyleElement(options);\n    update = applyToTag.bind(null, style, options);\n\n    remove = function remove() {\n      removeStyleElement(style);\n    };\n  }\n\n  update(obj);\n  return function updateStyle(newObj) {\n    if (newObj) {\n      if (newObj.css === obj.css && newObj.media === obj.media && newObj.sourceMap === obj.sourceMap) {\n        return;\n      }\n\n      update(obj = newObj);\n    } else {\n      remove();\n    }\n  };\n}\n\nmodule.exports = function (list, options) {\n  options = options || {}; // Force single-tag solution on IE6-9, which has a hard limit on the # of <style>\n  // tags it will allow on a page\n\n  if (!options.singleton && typeof options.singleton !== 'boolean') {\n    options.singleton = isOldIE();\n  }\n\n  list = list || [];\n  var lastIdentifiers = modulesToDom(list, options);\n  return function update(newList) {\n    newList = newList || [];\n\n    if (Object.prototype.toString.call(newList) !== '[object Array]') {\n      return;\n    }\n\n    for (var i = 0; i < lastIdentifiers.length; i++) {\n      var identifier = lastIdentifiers[i];\n      var index = getIndexByIdentifier(identifier);\n      stylesInDom[index].references--;\n    }\n\n    var newLastIdentifiers = modulesToDom(newList, options);\n\n    for (var _i = 0; _i < lastIdentifiers.length; _i++) {\n      var _identifier = lastIdentifiers[_i];\n\n      var _index = getIndexByIdentifier(_identifier);\n\n      if (stylesInDom[_index].references === 0) {\n        stylesInDom[_index].updater();\n\n        stylesInDom.splice(_index, 1);\n      }\n    }\n\n    lastIdentifiers = newLastIdentifiers;\n  };\n};\n\n//# sourceURL=webpack://javascript/./node_modules/style-loader/dist/runtime/injectStylesIntoStyleTag.js?");

/***/ })

/******/ 	});
/************************************************************************/
/******/ 	// The module cache
/******/ 	var __webpack_module_cache__ = {};
/******/ 	
/******/ 	// The require function
/******/ 	function __webpack_require__(moduleId) {
/******/ 		// Check if module is in cache
/******/ 		var cachedModule = __webpack_module_cache__[moduleId];
/******/ 		if (cachedModule !== undefined) {
/******/ 			return cachedModule.exports;
/******/ 		}
/******/ 		// Create a new module (and put it into the cache)
/******/ 		var module = __webpack_module_cache__[moduleId] = {
/******/ 			id: moduleId,
/******/ 			// no module.loaded needed
/******/ 			exports: {}
/******/ 		};
/******/ 	
/******/ 		// Execute the module function
/******/ 		__webpack_modules__[moduleId](module, module.exports, __webpack_require__);
/******/ 	
/******/ 		// Return the exports of the module
/******/ 		return module.exports;
/******/ 	}
/******/ 	
/************************************************************************/
/******/ 	/* webpack/runtime/compat get default export */
/******/ 	(() => {
/******/ 		// getDefaultExport function for compatibility with non-harmony modules
/******/ 		__webpack_require__.n = (module) => {
/******/ 			var getter = module && module.__esModule ?
/******/ 				() => (module['default']) :
/******/ 				() => (module);
/******/ 			__webpack_require__.d(getter, { a: getter });
/******/ 			return getter;
/******/ 		};
/******/ 	})();
/******/ 	
/******/ 	/* webpack/runtime/define property getters */
/******/ 	(() => {
/******/ 		// define getter functions for harmony exports
/******/ 		__webpack_require__.d = (exports, definition) => {
/******/ 			for(var key in definition) {
/******/ 				if(__webpack_require__.o(definition, key) && !__webpack_require__.o(exports, key)) {
/******/ 					Object.defineProperty(exports, key, { enumerable: true, get: definition[key] });
/******/ 				}
/******/ 			}
/******/ 		};
/******/ 	})();
/******/ 	
/******/ 	/* webpack/runtime/hasOwnProperty shorthand */
/******/ 	(() => {
/******/ 		__webpack_require__.o = (obj, prop) => (Object.prototype.hasOwnProperty.call(obj, prop))
/******/ 	})();
/******/ 	
/******/ 	/* webpack/runtime/make namespace object */
/******/ 	(() => {
/******/ 		// define __esModule on exports
/******/ 		__webpack_require__.r = (exports) => {
/******/ 			if(typeof Symbol !== 'undefined' && Symbol.toStringTag) {
/******/ 				Object.defineProperty(exports, Symbol.toStringTag, { value: 'Module' });
/******/ 			}
/******/ 			Object.defineProperty(exports, '__esModule', { value: true });
/******/ 		};
/******/ 	})();
/******/ 	
/************************************************************************/
/******/ 	
/******/ 	// startup
/******/ 	// Load entry module and return exports
/******/ 	// This entry module can't be inlined because the eval devtool is used.
/******/ 	var __webpack_exports__ = __webpack_require__("./script.js");
/******/ 	
/******/ })()
;