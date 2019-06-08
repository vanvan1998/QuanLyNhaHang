const Employee = require('../models/employee.model.js');

// Create and Save a new Employee
exports.create = (req, res) => {
    // Validate username
    if (!req.body.username) {
        return res.send({
            message: "Employee employee name can not be empty"
        });
    }

    // Validate password
    if (!req.body.password) {
        return res.send({
            message: "Employee password can not be empty"
        });
    }

    // Validate role
    if (!req.body.role) {
        return res.send({
            message: "Employee role can not be empty"
        });
    }

    // Create a Employee
    const employee = new Employee({
        username: String,
        password: String,
        displayName: String,
        role: String,
        dateOfBirth: Date,
        identityNumber: String,
        phone: String
    });

    // Save Employee in the database
    employee.save()
        .then(data => {
            res.send(data);
            console.log("Send data!!");
        }).catch(err => {
            res.send({
                message: err.message || "Some error occurred while creating the Employee."
            });
        });
};

// Retrieve and return all employees from the database.
exports.findAll = (req, res) => {
    Employee.find()
        .then(employees => {
            res.send(employees);
        }).catch(err => {
            res.send({
                message: err.message || "Some error occurred while retrieving employees."
            });
        });
};

// Find a single employee with a employeeId
exports.findOne = (req, res) => {
    Employee.findById(req.params.employeeId)
        .then(employee => {
            if (!employee) {
                return res.send({
                    message: "Employee not found with id " + req.params.employeeId
                });
            }
            res.send(employee);
        }).catch(err => {
            if (err.kind === 'ObjectId') {
                return res.send({
                    message: "Employee not found with id " + req.params.employeeId
                });
            }
            return res.send({
                message: "Error retrieving employee with id " + req.params.employeeId
            });
        });
};

// Update a employee identified by the employeeId in the request
exports.update = (req, res) => {
    // Validate Request
    if (!req.body.password) {
        return res.send({
            message: "Employee password can not be empty"
        });
    }

    // Validate Request
    if (!req.body.role) {
        return res.send({
            message: "Employee role can not be empty"
        });
    }

    // Find employee and update it with the request body
    Employee.findByIdAndUpdate(req.params.employeeId, {
        password: req.body.password,
        role: req.body.role
    }, { new: true })
        .then(employee => {
            if (!employee) {
                return res.send({
                    message: "Employee not found with id " + req.params.employeeId
                });
            }
            res.send({ message: "Employee updated successfully!" });
        }).catch(err => {
            if (err.kind === 'ObjectId') {
                return res.send({
                    message: "Employee not found with id " + req.params.employeeId
                });
            }
            return res.send({
                message: "Error updating employee with id " + req.params.employeeId
            });
        });
};

// Delete a employee with the specified employeeId in the request
exports.delete = (req, res) => {
    Employee.findByIdAndRemove(req.params.employeeId)
        .then(employee => {
            if (!employee) {
                return res.send({
                    message: "Employee not found with id " + req.params.employeeId
                });
            }
            res.send({ message: "Employee deleted successfully!" });
        }).catch(err => {
            if (err.kind === 'ObjectId' || err.name === 'NotFound') {
                return res.send({
                    message: "Employee not found with id " + req.params.employeeId
                });
            }
            return res.send({
                message: "Could not delete employee with id " + req.params.employeeId
            });
        });
};