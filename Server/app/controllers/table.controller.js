const Table = require('../models/table.model.js');

// Create and Save a new Table
exports.create = (req, res) => {
    // Validate request
    if (!req.body.number) {
        return res.send({
            message: "Table's number can not be empty"
        });
    }

    // Validate request
    if (!req.body.status) {
        return res.send({
            message: "Table's status can not be empty"
        });
    }

    // Validate request
    if (!req.body.numberOfSeat) {
        return res.send({
            message: "Table's numberOfSeat can not be empty"
        });
    }

    // Validate request
    if (!req.body.type) {
        return res.send({
            message: "Table's type can not be empty"
        });
    }

    // Create a Table
    const table = new Table({
        number: req.body.number,
        note: req.body.note,
        numberOfSeat: req.body.numberOfSeat,
        status: req.body.status,
        type: req.body.type,
        customer: {
            fullName: req.body.customer.fullName,
            phone: req.body.customer.phone
        },
        time: req.body.time
    });

    // Save Table in the database
    table.save()
        .then(data => {
            res.send({ message: "create successful" });
        }).catch(err => {
            res.send({
                message: err.message || "Some error occurred while creating the Table."
            });
        });
};

// Retrieve and return all tables with status and type from the database.
exports.findAllWithStatusAndType = (req, res) => {
    var status = req.params.status;
    const type = req.params.type;

    Table.find({ "status": status, "type": type })
        .then(tables => {
            res.send(tables);
        }).catch(err => {
            res.send({
                message: err.message || "Some error occurred while retrieving tables."
            });
        });
};

exports.findAllWithCustomerName = (req, res) => {
    Table.find({"customer.fullName": req.body.fullName})   
        .then(tables => {
            res.send(tables);
        }).catch(err => {
            res.send({
                message: err.message || "Some error occurred while retrieving tables." //alo nghe ko
            });
        });
};

exports.findAll = (req, res) => {

    Table.find()
        .then(tables => {
            res.send(tables);
        }).catch(err => {
            res.send({
                message: err.message || "Some error occurred while retrieving tables."
            });
        });
};

exports.countUsing = async function (req, res) {
    var count = await Table.countDocuments({ status: "booked" });
    res.send({ count: count });
};

exports.countEmpty = async function (req, res) {

    var countstandard4 = 0;
    var countstandard8 = 0;
    var countstandard12 = 0;

    var countVIP4 = 0;
    var countVIP8 = 0;
    var countVIP12 = 0;

    var count = 0;
    
    await Table.find().then(tables =>{
        count = tables.length;
        tables.forEach(element => {
            if (element.type == "standard" && element.numberOfSeat == 4){
                countstandard4++;
            }
            if (element.type == "standard" && element.numberOfSeat == 8){
                countstandard8++;
            }
            if (element.type == "standard" && element.numberOfSeat == 12){
                countstandard12++;
            }
            if (element.type == "VIP" && element.numberOfSeat == 4){
                countVIP4++;
            }
            if (element.type == "VIP" && element.numberOfSeat == 8){
                countVIP8++;
            }
            if (element.type == "VIP" && element.numberOfSeat == 12){
                countVIP12++;
            }
        });
    }).catch(err => {
        res.send({
            message: err.message || "Some error occurred while retrieving tables."
        });
    });


    res.send({count: count, countstandard4: countstandard4, countstandard8: countstandard8, countstandard12: countstandard12, countVIP4: countVIP4, countVIP8: countVIP8, countVIP12: countVIP12 });
};

// Find a single table with a tableId
exports.findOne = (req, res) => {
    Table.findOne({ "number": req.params.tableNumber })
        .then(table => {
            if (!table) {
                return res.send({
                    message: "Table not found with id " + req.params.tableId,
                    code: 0
                });
            }
            res.send({ table, code: 1 });
        }).catch(err => {
            if (err.kind === 'ObjectId') {
                return res.send({
                    message: "Table not found with id " + req.params.tableId,
                    code: 0
                });
            }
            return res.send({
                message: "Error retrieving table with id " + req.params.tableId,
                code: 0
            });
        });
};

// Update a table identified by the tableId in the request
exports.update = (req, res) => {
    // Validate Request
    if (!req.body.number) {
        return res.send({
            message: "Table number can not be empty"
        });
    }

    // Validate Request
    if (!req.body.numberOfSeat) {
        return res.send({
            message: "Table numberOfSeat can not be empty"
        });
    }

    // Validate Request
    if (!req.body.status) {
        return res.send({
            message: "Table status can not be empty"
        });
    }

    // Validate Request
    if (!req.body.type) {
        return res.send({
            message: "Table type can not be empty"
        });
    }

    // Find table and update it with the request body
    Table.findByIdAndUpdate(req.params.tableId, {
        number: req.body.number,
        note: req.body.note,
        numberOfSeat: req.body.numberOfSeat,
        status: req.body.status,
        type: req.body.type,
        customer: {
            fullName: req.body.customer.fullName,
            phone: req.body.customer.phone
        },
        time: req.body.time
    }, { new: true })
        .then(table => {
            if (!table) {
                return res.send({
                    message: "Table not found with id " + req.params.tableId
                });
            }
            res.send({ message: "Table update successfully!" });
        }).catch(err => {
            if (err.kind === 'ObjectId') {
                return res.send({
                    message: "Table not found with id " + req.params.tableId
                });
            }
            return res.send({
                message: "Error updating table with id " + req.params.tableId
            });
        });
};

exports.book = (req, res) => {
    // Validate Request
    if (!req.body.number) {
        return res.send({
            message: "Table number can not be empty"
        });
    }

    // Find table and update it with the request body
    Table.findOneAndUpdate({ number: req.body.number }, {
        note: req.body.note,
        status: req.body.status,
        customer: {
            fullName: req.body.customer.fullName,
            phone: req.body.customer.phone
        },
        time: req.body.time
    }, { new: true })
        .then(table => {
            if (!table) {
                return res.send({
                    message: "Table not found with id " + req.params.tableId
                });
            }
            res.send({ message: "Table update successfully!" });
        }).catch(err => {
            if (err.kind === 'ObjectId') {
                return res.send({
                    message: "Table not found with id " + req.params.tableId
                });
            }
            return res.send({
                message: "Error updating table with id " + req.params.tableId
            });
        });
};

// Delete a table with the specified tableId in the request
exports.delete = (req, res) => {
    Table.findByIdAndRemove(req.params.tableId)
        .then(table => {
            if (!table) {
                return res.send({
                    message: "Table not found with id " + req.params.tableId
                });
            }
            res.send({ message: "Table deleted successfully!" });
        }).catch(err => {
            if (err.kind === 'ObjectId' || err.name === 'NotFound') {
                return res.send({
                    message: "Table not found with id " + req.params.tableId
                });
            }
            return res.send({
                message: "Could not delete table with id " + req.params.tableId
            });
        });
};