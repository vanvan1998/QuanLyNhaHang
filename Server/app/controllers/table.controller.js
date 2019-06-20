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
        status: "empty",
        type: req.body.type,
        customer: {
            fullName: "",
            phone: ""
        }
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
exports.findAllWithStatusAndType = async function (req, res) {
    try {
        var tables = await Table.find({ status: req.params.status, type: req.params.type });
        res.send(tables);
    } catch (error) {
        res.send({
            message: error.message || "Some error occurred while retrieving tables."
        });
    }
};

exports.findAllWithCustomerName = async function (req, res) {
    try {
        var tables = await Table.find({ "customer.fullName": req.body.fullName });
        res.send(tables);
    } catch (error) {
        res.send({
            message: error.message || "Some error occurred while retrieving tables."
        });
    }
};

exports.findAll = async (req, res) => {
    try {
        var tables = await Table.find();
        res.send(tables);
    } catch (error) {
        res.send({
            message: error.message || "Some error occurred while retrieving tables."
        });
    }
};

exports.countUsing = async function (req, res) {
    try {
        var count = await Table.countDocuments({ status: "booked" });
        res.send({ count: count });
    } catch (error) {
        res.send({
            message: error.message || "Some error occurred while retrieving tables."
        });
    }
};

exports.countEmpty = async function (req, res) {
    var count = new Promise((resolve, reject) => {
        Table.countDocuments({ status: "empty" }, (err, result) => {
            if (err) return reject(err);
            resolve(result);
        })
    })

    var countstandard4 = new Promise((resolve, reject) => {
        Table.countDocuments({ status: "empty", type: "standard", numberOfSeat: 4 }, (err, result) => {
            if (err) return reject(err);
            resolve(result);
        })
    })

    var countstandard8 = new Promise((resolve, reject) => {
        Table.countDocuments({ status: "empty", type: "standard", numberOfSeat: 8 }, (err, result) => {
            if (err) return reject(err);
            resolve(result);
        })
    })

    var countstandard12 = new Promise((resolve, reject) => {
        Table.countDocuments({ status: "empty", type: "standard", numberOfSeat: 12 }, (err, result) => {
            if (err) return reject(err);
            resolve(result);
        })
    })

    var countVIP4 = new Promise((resolve, reject) => {
        Table.countDocuments({ status: "empty", type: "VIP", numberOfSeat: 4 }, (err, result) => {
            if (err) return reject(err);
            resolve(result);
        })
    })

    var countVIP8 = new Promise((resolve, reject) => {
        Table.countDocuments({ status: "empty", type: "VIP", numberOfSeat: 8 }, (err, result) => {
            if (err) return reject(err);
            resolve(result);
        })
    })

    var countVIP12 = new Promise((resolve, reject) => {
        Table.countDocuments({ status: "empty", type: "VIP", numberOfSeat: 12 }, (err, result) => {
            if (err) return reject(err);
            resolve(result);
        })
    })

    Promise.all([count, countstandard4, countstandard8, countstandard12, countVIP4, countVIP8, countVIP12]).then(values => {
        res.send({ count: values[0], countstandard4: values[1], countstandard8: values[2], countstandard12: values[3], countVIP4: values[4], countVIP8: values[5], countVIP12: values[6] });
    }).catch(error => {
        res.send(error.message);
    });
};

// Find a single table with a tableNumber
exports.findOne = async function (req, res) {
    try {
        var table = Table.findOne({ "number": req.params.tableNumber });
        res.send({ table });
    } catch (error) {
        res.send({
            message: error.message || "Some error occurred while retrieving tables."
        });
    }
};

// Update a table identified by the tableId in the request
exports.update = (req, res) => {
    // Validate Request
    if (!req.body.number) {
        return res.send({
            message: "Table number can not be empty"
        });
    }

    if (!req.body.numberOfSeat) {
        return res.send({
            message: "Table numberOfSeat can not be empty"
        });
    }

    if (!req.body.status) {
        return res.send({
            message: "Table status can not be empty"
        });
    }

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
        }
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