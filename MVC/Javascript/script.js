const Model = require("./model");
const View = require("./view");
const Controller = require("./controller");
require("./style.css");

const app = new Controller(new Model(), new View());
