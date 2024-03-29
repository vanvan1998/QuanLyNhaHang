const express = require('express');
const bodyParser = require('body-parser');

// create express app
const app = express();

// parse application/x-www-form-urlencoded
app.use(bodyParser.urlencoded({ extended: true }))

// parse application/json
app.use(bodyParser.json())

// Configuring the database
const dbConfig = require('./config/database.config.js');
const mongoose = require('mongoose');

mongoose.Promise = global.Promise;

// Connecting to the database
mongoose.connect(dbConfig.url, {
	useNewUrlParser: true, useFindAndModify: false 
}).then(() => {
    console.log("Successfully connected to the database");    
}).catch(err => {
    console.log('Could not connect to the database. Exiting now...', err);
    process.exit();
});
mongoose.set('useFindAndModify', true); 

require('./app/routes/table.routes.js')(app);
require('./app/routes/employee.routes.js')(app);
require('./app/routes/login.routes.js')(app);
require('./app/routes/customer.routes.js')(app);
require('./app/routes/bill.routes.js')(app);
require('./app/routes/food.routes.js')(app);
require('./app/routes/promotion.routes.js')(app);
require('./app/routes/servicefee.routes.js')(app);

// listen for requests
app.listen(3000, () => {
    console.log("Server is listening on port 3000");
});