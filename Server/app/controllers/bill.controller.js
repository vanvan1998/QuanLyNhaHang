const Bill = require('../models/bill.model.js');

// Create and Save a new Bill
exports.create = (req, res) => {
    // Validate request
    if (!req.body.tableID) {
        return res.send({
            message: "Bill's tableID can not be empty"
        });
    }

    // Validate request
    if (!req.body.employeeID) {
        return res.send({
            message: "Bill's employeeID can not be empty"
        });
    }

    // Validate request
    if (!req.body.customerID) {
        return res.send({
            message: "Bill's customerID can not be empty"
        });
    }

    // Create a Bill
    const bill = new Bill({
        tableID: req.body.tableID,
        employeeID: req.body.employeeID,
        customerID: req.body.customerID,
        billNumber: req.body.billNumber,
        status: req.body.status,
        promotion: req.body.promotion,
        total: req.body.total,
        menu: req.body.menu,
        time: req.body.time
    });

    // Save Bill in the database
    bill.save()
        .then(data => {
            res.send({ message: "create successful" });
        }).catch(err => {
            res.send({
                message: err.message || "Some error occurred while creating the Bill."
            });
        });
};

// Retrieve and return all bills with status and type from the database.
exports.findAll = (req, res) => {

    Bill.find({})
        .then(bills => {
            res.send(bills);
        }).catch(err => {
            res.send({
                message: err.message || "Some error occurred while retrieving bills."
            });
        });
};

// Find a single bill with a billId
exports.findOne = (req, res) => {
    Bill.findById(req.params.billId)
        .then(bill => {
            if (!bill) {
                return res.send({
                    message: "Bill not found with id " + req.params.billId
                });
            }
            res.send(bill);
        }).catch(err => {
            if (err.kind === 'ObjectId') {
                return res.send({
                    message: "Bill not found with id " + req.params.billId
                });
            }
            return res.send({
                message: "Error retrieving bill with id " + req.params.billId
            });
        });
};

// Update a bill identified by the billId in the request
exports.update = (req, res) => {
    //Validate request
    if (!req.body.tableID) {
        return res.send({
            message: "Bill's tableID can not be empty"
        });
    }

    // Validate request
    if (!req.body.employeeID) {
        return res.send({
            message: "Bill's employeeID can not be empty"
        });
    }

    // Validate request
    if (!req.body.customerID) {
        return res.send({
            message: "Bill's customerID can not be empty"
        });
    }

    // Find bill and update it with the request body
    Bill.findByIdAndUpdate(req.params.billId, {
        tableID: req.body.tableID,
        employeeID: req.body.employeeID,
        customerID: req.body.customerID,
        billNumber: req.body.billNumber,
        status: req.body.status,
        promotion: req.body.promotion,
        total: req.body.total,
        menu: req.body.menu,
        time: req.body.time
    }, { new: true })
        .then(bill => {
            if (!bill) {
                return res.status(404).send({
                    message: "Bill not found with id " + req.params.billId
                });
            }
            res.send({ message: "Bill updated successfully!" });
        }).catch(err => {
            if (err.kind === 'ObjectId') {
                return res.status(404).send({
                    message: "Bill not found with id " + req.params.billId
                });
            }
            return res.send({
                message: "Error updating bill with id " + req.params.billId
            });
        });
};

// Delete a bill with the specified billId in the request
exports.delete = (req, res) => {
    Bill.findByIdAndRemove(req.params.billId)
        .then(bill => {
            if (!bill) {
                return res.send({
                    message: "Bill not found with id " + req.params.billId
                });
            }
            res.send({ message: "Bill deleted successfully!" });
        }).catch(err => {
            if (err.kind === 'ObjectId' || err.name === 'NotFound') {
                return res.send({
                    message: "Bill not found with id " + req.params.billId
                });
            }
            return res.send({
                message: "Could not delete bill with id " + req.params.billId
            });
        });
};