CREATE DATABASE IF NOT EXISTS launchforce;

use launchforce;

CREATE TABLE IF NOT EXISTS user_master (
    user_id VARCHAR(100) NOT NULL,       -- 32-bit GUID number, assuming it's stored as a string
    role_id INT,                         -- foreign key from role_master table
    dept_id INT,                         -- foreign key from department_master table
    org_id VARCHAR(100),                 -- from vendor master table
    first_name VARCHAR(100),             -- first name
    last_name VARCHAR(100),              -- last name
    user_name VARCHAR(100),              -- user name
    user_password VARCHAR(100),               -- password
    is_new_user BOOLEAN DEFAULT 0,       -- 0 if the user is new & yet to login, 1 if logged in once
    email VARCHAR(100),                  -- email address
    mobile VARCHAR(100),                 -- mobile number
    location INT,                        -- foreign key from location_master table
    created_by VARCHAR(100),             -- created by
    created_date DATETIME DEFAULT CURRENT_TIMESTAMP,               -- date when created
    modified_by VARCHAR(100),            -- modified by
    modified_date DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,              -- date when modified
    
    PRIMARY KEY (user_id)               -- assuming user_id is the primary key
);

CREATE TABLE IF NOT EXISTS vendor_master (
    vendor_id VARCHAR(100) NOT NULL,      -- 32-bit GUID, typically stored as a 36-character string
    vendor_name VARCHAR(100),            -- Vendor name, adjust length if needed
    location_id INT,                    -- Integer for location_id
    skills_set VARCHAR(1000),            -- Skills set in varchar format
    created_by VARCHAR(100),             -- created by
    created_date DATETIME DEFAULT CURRENT_TIMESTAMP,               -- date when created
    modified_by VARCHAR(100),            -- modified by
    modified_date DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,              -- date when modified
    PRIMARY KEY (vendor_id)             -- Assuming vendor_id is the primary key
);

CREATE TABLE IF NOT EXISTS role_master (
    role_id INT AUTO_INCREMENT PRIMARY KEY,  -- Auto-incrementing integer for role_id
    role_name VARCHAR(100),                  -- Role name (adjust length if needed)
    clearance_level INT,                     -- Integer for clearance level
    org_type INT,                            -- 0 for Dover, 1 for Vendor
    created_by VARCHAR(100),             -- created by
    created_date DATETIME DEFAULT CURRENT_TIMESTAMP,               -- date when created
    modified_by VARCHAR(100),            -- modified by
    modified_date DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP
);

CREATE TABLE IF NOT EXISTS department_master (
    dept_id INT AUTO_INCREMENT PRIMARY KEY,  -- Auto-incrementing integer for dept_id
    dept_name VARCHAR(100),                  -- Department name (adjust length if needed)
    created_by VARCHAR(100),             -- created by
    created_date DATETIME DEFAULT CURRENT_TIMESTAMP,               -- date when created
    modified_by VARCHAR(100),            -- modified by
    modified_date DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP
);

CREATE TABLE IF NOT EXISTS location_master (
    location_id INT AUTO_INCREMENT PRIMARY KEY,  -- Auto-incrementing integer for location_id
    location_type INT,                          -- 0 for Dover, 1 for Vendor
    location_name VARCHAR(100),                 -- Location name (adjust length if needed)
    created_by VARCHAR(100),             -- created by
    created_date DATETIME DEFAULT CURRENT_TIMESTAMP,               -- date when created
    modified_by VARCHAR(100),            -- modified by
    modified_date DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP
);

CREATE TABLE IF NOT EXISTS permission_master (
    permission_id INT AUTO_INCREMENT PRIMARY KEY,            -- Auto-incrementing integer for id
    permission_name VARCHAR(100),                  -- Permission name (length adjusted to 100)
    created_by VARCHAR(100),                       -- User who created the entry (length adjusted to 100)
    created_date DATETIME DEFAULT CURRENT_TIMESTAMP,   -- Automatically set to current timestamp on creation
    modified_by VARCHAR(100),                      -- User who last modified the entry (length adjusted to 100)
    modified_date DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP  -- Automatically updated on modification
);

CREATE TABLE IF NOT EXISTS role_permission_association (
    id INT auto_increment primary key,
    permission_id INT,                           -- Foreign key from permission_master table
    role_id INT,                                 -- Foreign key from role_master table
    created_by VARCHAR(100),                     -- User who created the association (length adjusted to 100)
    created_date DATETIME DEFAULT CURRENT_TIMESTAMP,  -- Automatically set to current timestamp on creation
    modified_by VARCHAR(100),                    -- User who last modified the association (length adjusted to 100)
    modified_date DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP  -- Automatically updated on modification
);

CREATE TABLE IF NOT EXISTS project_master (
    project_id INT AUTO_INCREMENT PRIMARY KEY,        -- Auto-incrementing integer for project_id
    project_name VARCHAR(100),                         -- Project name (length adjusted to 100)
    dept_id INT,                                      -- Foreign key from department_master table
    created_by VARCHAR(100),                          -- User who created the entry (length adjusted to 100)
    created_date DATETIME DEFAULT CURRENT_TIMESTAMP,  -- Automatically set to current timestamp on creation
    modified_by VARCHAR(100),                         -- User who last modified the entry (length adjusted to 100)
    modified_date DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP  -- Automatically updated on modification  
);

CREATE TABLE IF NOT EXISTS user_project_association (
    id INT AUTO_INCREMENT PRIMARY KEY,                 -- Auto-incrementing integer for id
    user_id VARCHAR(100),                              -- User ID (length adjusted to 100)
    project_id INT,                                    -- Foreign key from project_master table
    created_by VARCHAR(100),                           -- User who created the association (length adjusted to 100)
    created_date DATETIME DEFAULT CURRENT_TIMESTAMP,   -- Automatically set to current timestamp on creation
    modified_by VARCHAR(100),                          -- User who last modified the association (length adjusted to 100)
    modified_date DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP  -- Automatically updated on modification
);

CREATE TABLE IF NOT EXISTS vendor_master (
    vendor_id VARCHAR(100) PRIMARY KEY,               -- 32-bit GUID, typically stored as a 36-character string (including hyphens)
    vendor_name VARCHAR(100),                        -- Vendor name (adjust length as needed)
    location_id INT,                                 -- Foreign key from location_master table
    skills_set VARCHAR(255),                         -- Skills set for the vendor (adjust length as needed)
    created_by VARCHAR(100),                         -- User who created the entry
    created_date DATETIME DEFAULT CURRENT_TIMESTAMP, -- Automatically set to current timestamp on creation
    modified_by VARCHAR(100),                        -- User who last modified the entry
    modified_date DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP
);

CREATE TABLE IF NOT EXISTS vendor_ratecard_master (
    card_id INT AUTO_INCREMENT PRIMARY KEY,                 -- Auto-incrementing integer for card_id
    vendor_id VARCHAR(100),                                 -- Foreign key from vendor_master table (GUID format)
    job_position VARCHAR(100),                              -- Position or role for the vendor (adjust length as needed)
    experience INT,                                         -- Experience in months
    rate_card DOUBLE,                                       -- Rate per hour (using DOUBLE for precision)
    created_by VARCHAR(100),                                -- User who created the entry
    created_date DATETIME DEFAULT CURRENT_TIMESTAMP,        -- Automatically set to current timestamp on creation
    modified_by VARCHAR(100),                               -- User who last modified the entry
    modified_date DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP  -- Automatically updated on modification
);

CREATE TABLE IF NOT EXISTS status_master (
    status_id INT AUTO_INCREMENT PRIMARY KEY,           -- Auto-incrementing integer for status_id
    status_type INT,                                    -- Status type (0 - requisition, 1 - CV, 2 - interviewer)
    status_name VARCHAR(100),                           -- Name of the status (length adjusted to 100)
    created_by VARCHAR(100),                            -- User who created the entry
    created_date DATETIME DEFAULT CURRENT_TIMESTAMP,    -- Automatically set to current timestamp on creation
    modified_by VARCHAR(100),                           -- User who last modified the entry
    modified_date DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP  -- Automatically updated on modification
);

CREATE TABLE IF NOT EXISTS requisition_table (
    req_id VARCHAR(100) PRIMARY KEY,                       -- 32-bit GUID for req_id
    job_title VARCHAR(100),                               -- Job title (length adjusted to 100)
    dept_id INT,                                          -- Foreign key from department_master table
    project_id INT,                                       -- Foreign key from project_master table or NULL
    hiring_manager VARCHAR(100),                          -- User ID from user_master table
    positions INT,                                        -- Number of positions to hire
    duration INT,                                         -- Duration (number of months)
    start_date DATETIME,                                  -- Start date and time
    end_date DATETIME,                                    -- End date and time
    employee_type INT,                                    -- 0: new, 1: replacement
    replacement_emp VARCHAR(100),                         -- Employee to be replaced (NULL if not applicable)
    competency INT,                                       -- 0: new, 1: existing
    employment_type INT,                                  -- 0: contract full-time, 1: contract part-time, 2: freelance
    location_type INT,                                    -- 0: remote, 1: onsite, 2: hybrid
    location_id INT,                                      -- Foreign key from location_master table
    working_hours DOUBLE,                                 -- Working hours per day (using DOUBLE for precision)
    roles_and_responsibility VARCHAR(1000),               -- Roles and responsibilities (comma-separated values)
    min_qualification VARCHAR(1000),                      -- Minimum qualifications (comma-separated values)
    required_skills VARCHAR(1000),                        -- Required skills (comma-separated values)
    preferred_skills VARCHAR(1000) DEFAULT NULL,          -- Preferred skills (comma-separated values, NULL if not applicable)
    specialization VARCHAR(1000) DEFAULT NULL,            -- Specialization (comma-separated values, NULL if not applicable)
    total_exp DOUBLE,                                     -- Total experience (years and months, in double format)
    relevant_exp DOUBLE,                                  -- Relevant experience (years and months, in double format)
    CTQ VARCHAR(1000) DEFAULT NULL,                       -- Critical Quality (CTQ) description, NULL if not applicable
    benefits VARCHAR(1000),                               -- Benefits offered (description)
    special_requirements VARCHAR(1000),                    -- Special requirements (description)
    estimated_budget DOUBLE,                              -- Estimated budget for the requisition
    emp_references VARCHAR(1000),                         -- References (comma-separated values)
    sourcing_manager VARCHAR(100),                        -- User ID from user_master table (sourcing manager)
    rate_card_id VARCHAR(1000),                           -- Rate card IDs (comma-separated values, from vendor_ratecard_master table)
    status_id INT,                                        -- Status of the requisition
    comments VARCHAR(1000),                               -- Comments or additional notes
    created_by VARCHAR(100),                              -- User who created the requisition
    created_date DATETIME DEFAULT CURRENT_TIMESTAMP,      -- Timestamp when the requisition was created
    modified_by VARCHAR(100),                             -- User who last modified the requisition
    modified_date DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP -- Timestamp when modified
);

CREATE TABLE IF NOT EXISTS req_vendor_association (
    id INT AUTO_INCREMENT PRIMARY KEY,                    -- Auto-incrementing integer for the association ID
    req_id VARCHAR(100),                                    -- Foreign key from requisition_table (GUID format)
    vendor_id VARCHAR(100),                                 -- Foreign key from vendor_master table (GUID format)
    created_by VARCHAR(100),                               -- User who created the association
    created_date DATETIME DEFAULT CURRENT_TIMESTAMP,       -- Automatically set to current timestamp on creation
    modified_by VARCHAR(100),                              -- User who last modified the association
    modified_date DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP  -- Automatically updated on modification
);

CREATE TABLE IF NOT EXISTS req_approver_association (
    id INT AUTO_INCREMENT PRIMARY KEY,                    -- Auto-incrementing integer for the association ID
    req_id VARCHAR(100),                                    -- Foreign key from requisition_table (GUID format)
    approver_id VARCHAR(100),                               -- Foreign key from user_master table (user_id)
    status_id INT,                                            -- Foreign key from status_master table
    is_mandatory BOOLEAN,                                  -- Mandatory status for the approver (1 = yes, 0 = no)
    created_by VARCHAR(100),                               -- User who created the association
    created_date DATETIME DEFAULT CURRENT_TIMESTAMP,       -- Automatically set to current timestamp on creation
    modified_by VARCHAR(100),                              -- User who last modified the association
    modified_date DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP  -- Automatically updated on modification
);

CREATE TABLE IF NOT EXISTS req_cv_association (
    cv_id INT AUTO_INCREMENT PRIMARY KEY,                          -- Auto-incrementing integer for the CV association ID
    req_id VARCHAR(100),                                             -- Foreign key from requisition_table (GUID format)
    emp_name VARCHAR(100),                                              -- Name of the CV submitter
    mobile VARCHAR(20),                                             -- Mobile number of the CV submitter
    email VARCHAR(100),                                             -- Email address of the CV submitter
    file_id BLOB,                                                   -- Binary large object for the file (assuming file upload as BLOB type)
    uploaded_by VARCHAR(100),                                       -- User ID from user_master table who uploaded the CV
    status_id INT,                                                     -- Foreign key from status_master table (status_id)
    comments VARCHAR(1000),                                         -- Comments about the CV (comma-separated values)
    average_rating DOUBLE,                                          -- Average rating for the CV (double precision)
    created_by VARCHAR(100),                                        -- User who created the CV association
    created_date DATETIME DEFAULT CURRENT_TIMESTAMP,                -- Timestamp when the CV was created
    modified_by VARCHAR(100),                                       -- User who last modified the CV association
    modified_date DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP  -- Timestamp when modified
);

CREATE TABLE IF NOT EXISTS req_interviewer_association (
    id INT AUTO_INCREMENT PRIMARY KEY,                            -- Auto-incrementing integer for the association ID
    req_id VARCHAR(100),                                          -- Foreign key from requisition_table (GUID format)
    cv_id INT,                                                    -- Foreign key from req_cv_association (cv_id)
    round INT,                                                    -- Interview round number (integer)
    interviewer_id VARCHAR(100),                                  -- Foreign key from user_master (user_id)
    topics_to_address VARCHAR(1000),                              -- Topics to address in the interview (VARCHAR)
    rating INT,                    								  -- Rating scale (0 to 10)
    interviewer_comments VARCHAR(1000),                           -- Interviewer's comments
    status_id INT,                                                -- Status: 0 = reject, 1 = select
    schedule_time DATETIME,                                       -- Scheduled interview time
    is_accepted BOOLEAN,                                          -- Whether the interview is accepted (true/false)
    vendor_comments VARCHAR(1000),                                -- Vendor-specific comments
    created_by VARCHAR(100),                                       -- User who created the record
    created_date DATETIME DEFAULT CURRENT_TIMESTAMP,              -- Timestamp when the record was created
    modified_by VARCHAR(100),                                      -- User who last modified the record
    modified_date DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP  -- Timestamp when modified
);

CREATE TABLE IF NOT EXISTS sow_association (
    id INT AUTO_INCREMENT PRIMARY KEY,                             -- Auto-incrementing integer for the association ID
    cv_id INT,                                                     -- Foreign key from req_cv_association (cv_id)
    req_id VARCHAR(100),                                             -- Foreign key from requisition_table (GUID format)
    Sow_doc BLOB,                                                  -- Binary large object for the SOW file (assuming file upload as BLOB)
    comments VARCHAR(1000),                                         -- Comments related to the SOW (separated by "$")
    created_by VARCHAR(100),                                        -- User who created the record
    created_date DATETIME DEFAULT CURRENT_TIMESTAMP,                -- Timestamp when the record was created
    modified_by VARCHAR(100),                                       -- User who last modified the record
    modified_date DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP  -- Timestamp when modified
);






