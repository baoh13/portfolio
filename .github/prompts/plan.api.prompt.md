# API Endpoint Planning Prompt

## Purpose
Generate comprehensive API endpoint requirements including detailed acceptance criteria, technical specifications, and feature documentation.

## Instructions
You are an expert API architect tasked with creating detailed requirements for a new REST API endpoint. Generate both a comprehensive story/task description and a detailed feature specification file.

### Input Parameters
- **Endpoint Name**: The name of the API endpoint (e.g., "contacts", "users", "orders")
- **HTTP Method**: The primary HTTP method (GET, POST, PUT, DELETE, PATCH)
- **Brief Description**: A short description of what the endpoint should do
- **Additional Requirements**: Any specific requirements or constraints

### Output Requirements

#### 1. Generate Story/Task Description
Create a detailed story/task description following this structure:

**Title**: Add new {HTTP_METHOD} endpoint to {Endpoint} API with paging, sorting, validation, RFC 5988, HATEOAS, and OpenAPI support

**Type**: Story / Task
**Priority**: Medium
**Assignee**: [Assign to appropriate developer]
**Labels**: api, {endpoint}, backend, paging, sorting, validation, rfc5988, hateoas, openapi

**Description**:
Implement a new {HTTP_METHOD} endpoint in the {Endpoint} API to {brief_description}. The endpoint should support filtering, paging, and sorting (for GET endpoints), with robust validation. It must include RFC 5988-compliant pagination links, HATEOAS-style hypermedia navigation, and be documented using the OpenAPI specification.

**Acceptance Criteria**:

For GET endpoints:
• New {HTTP_METHOD} `/{endpoint}` endpoint is added
• Supports optional query parameters for filtering (e.g., relevant fields)
• Supports paging via `limit` and `offset` query parameters
  • `limit`: number of records to return (default: 25, max: 100)
  • `offset`: number of records to skip (default: 0)
  • Validation: `limit` must be a positive integer ≤ 100; `offset` must be a non-negative integer
• Supports sorting via `sortBy` and `sortOrder` query parameters
  • `sortBy`: field to sort by (e.g., relevant fields)
  • `sortOrder`: `asc` or `desc` (default: `asc`)
  • Validation: `sortBy` must be one of the allowed fields; `sortOrder` must be `asc` or `desc`
• Returns data in JSON format
• Response includes metadata: `totalCount`, `limit`, `offset`, `sortBy`, and `sortOrder` values
• Response headers include RFC 5988-compliant `Link` headers for pagination
• Response body includes HATEOAS `_links` object for each resource

For POST/PUT/PATCH endpoints:
• New {HTTP_METHOD} `/{endpoint}` endpoint is added
• Accepts JSON request body with appropriate schema validation
• Returns created/updated resource with 201/200 status code
• Includes HATEOAS `_links` object in response
• Validates all required fields and data types
• Returns appropriate error responses (400, 409, etc.) with descriptive messages

For DELETE endpoints:
• New DELETE `/{endpoint}/{id}` endpoint is added
• Returns 204 No Content on successful deletion
• Returns 404 if resource not found
• Returns 409 if resource cannot be deleted due to constraints

Common Requirements:
• Invalid parameters return appropriate 4xx error with descriptive message
• Endpoint is documented using OpenAPI 3.x with parameters, responses, and examples
• Supports Swagger UI or equivalent for interactive exploration
• Unit and integration tests are written
• API documentation is updated with examples and usage notes

**Technical Notes**:
• Use centralized validation logic for query parameters
• Implement helper to generate RFC 5988 `Link` headers (for GET endpoints)
• Implement HATEOAS link builder for resources
• Ensure OpenAPI spec is versioned and integrated into CI pipeline
• Consider indexing or caching strategies for performance
• Follow RESTful API design principles and HTTP status code best practices

#### 2. Create Feature Specification File
Also create a detailed feature specification file at `.github/features/apis/{endpoint}.md` with the following content:

```markdown
# {Endpoint} API Feature Specification

## Overview
This document specifies the requirements for the {Endpoint} API endpoint implementation.

## Endpoint Details

### Base Information
- **Endpoint**: `/{endpoint}`
- **HTTP Method**: {HTTP_METHOD}
- **Content Type**: `application/json`
- **Authentication**: [Specify auth requirements]
- **Rate Limiting**: [Specify rate limits if applicable]

### Request Specification

#### URL Parameters
[For endpoints with path parameters]
- `id` (string/number): Unique identifier for the resource

#### Query Parameters (for GET endpoints)
| Parameter | Type | Required | Default | Validation | Description |
|-----------|------|----------|---------|------------|-------------|
| `limit` | integer | No | 25 | 1-100 | Number of records to return |
| `offset` | integer | No | 0 | ≥0 | Number of records to skip |
| `sortBy` | string | No | [default field] | Allowed fields only | Field to sort by |
| `sortOrder` | string | No | asc | `asc` or `desc` | Sort direction |
| [Add filtering parameters as needed] | | | | | |

#### Request Body (for POST/PUT/PATCH endpoints)
```json
{
  // Define the request schema here
}
```

### Response Specification

#### Success Response (GET)
**Status Code**: 200 OK

**Headers**:
- `Content-Type: application/json`
- `Link: <url>; rel="next|prev|first|last"` (RFC 5988 pagination links)

**Body**:
```json
{
  "data": [
    {
      // Resource object with HATEOAS links
      "_links": {
        "self": { "href": "/api/{endpoint}/{id}", "method": "GET" },
        "update": { "href": "/api/{endpoint}/{id}", "method": "PUT" },
        "delete": { "href": "/api/{endpoint}/{id}", "method": "DELETE" }
      }
    }
  ],
  "metadata": {
    "totalCount": 150,
    "limit": 25,
    "offset": 0,
    "sortBy": "name",
    "sortOrder": "asc"
  },
  "_links": {
    "self": { "href": "/api/{endpoint}?limit=25&offset=0" },
    "next": { "href": "/api/{endpoint}?limit=25&offset=25" },
    "last": { "href": "/api/{endpoint}?limit=25&offset=125" }
  }
}
```

#### Success Response (POST/PUT/PATCH)
**Status Code**: 201 Created (POST) / 200 OK (PUT/PATCH)

**Body**:
```json
{
  // Created/updated resource with HATEOAS links
  "_links": {
    "self": { "href": "/api/{endpoint}/{id}", "method": "GET" }
  }
}
```

#### Success Response (DELETE)
**Status Code**: 204 No Content

### Error Responses

| Status Code | Condition | Response Body |
|-------------|-----------|---------------|
| 400 | Bad Request | `{"error": {"code": "INVALID_PARAMETER", "message": "Description"}}` |
| 401 | Unauthorized | `{"error": {"code": "UNAUTHORIZED", "message": "Authentication required"}}` |
| 403 | Forbidden | `{"error": {"code": "FORBIDDEN", "message": "Insufficient permissions"}}` |
| 404 | Not Found | `{"error": {"code": "NOT_FOUND", "message": "Resource not found"}}` |
| 409 | Conflict | `{"error": {"code": "CONFLICT", "message": "Resource already exists"}}` |
| 422 | Validation Error | `{"error": {"code": "VALIDATION_ERROR", "message": "Validation failed", "details": []}}` |
| 500 | Server Error | `{"error": {"code": "INTERNAL_ERROR", "message": "Internal server error"}}` |

## Validation Rules

### Input Validation
- [List specific validation rules for the endpoint]
- Required field validation
- Data type validation
- Format validation (email, phone, etc.)
- Business rule validation

### Business Rules
- [List any business logic constraints]
- Data consistency requirements
- Referential integrity rules

## Security Considerations
- Authentication requirements
- Authorization rules
- Input sanitization
- SQL injection prevention
- Rate limiting

## Performance Considerations
- Database indexing strategy
- Caching strategy
- Query optimization
- Response size limits

## Testing Requirements

### Unit Tests
- [ ] Request validation tests
- [ ] Business logic tests
- [ ] Error handling tests
- [ ] HATEOAS link generation tests

### Integration Tests
- [ ] End-to-end API tests
- [ ] Database interaction tests
- [ ] Authentication/authorization tests
- [ ] Performance tests

### Test Data
- Valid request examples
- Invalid request examples
- Edge case scenarios

## OpenAPI Specification
[Include or reference the OpenAPI/Swagger specification]

## Documentation Requirements
- API reference documentation
- Code examples in multiple languages
- Postman collection
- Integration guides

## Implementation Notes
- Database schema changes required
- Migration scripts needed
- Backwards compatibility considerations
- Deployment considerations

## Acceptance Criteria Checklist
- [ ] Endpoint implemented with correct HTTP method and path
- [ ] Request/response format matches specification
- [ ] Validation rules implemented and tested
- [ ] Error handling implemented
- [ ] HATEOAS links included in responses
- [ ] RFC 5988 pagination headers implemented (for GET endpoints)
- [ ] OpenAPI specification updated
- [ ] Unit and integration tests written and passing
- [ ] Performance requirements met
- [ ] Security requirements implemented
- [ ] Documentation updated
```

### Usage Example
To use this prompt:

1. **Input**: 
   - Endpoint Name: "contacts"
   - HTTP Method: "GET" 
   - Brief Description: "retrieve contact records with filtering and search capabilities"

2. **Generated Output**: Complete story/task description and feature specification file

### Customization Notes
- Adapt the template based on your specific API architecture
- Modify validation rules and business logic as needed
- Adjust authentication/authorization requirements
- Update error response formats to match your API standards
- Customize HATEOAS link structures as appropriate

---

**Instructions for AI**: When this prompt is used, generate both the story/task description AND create the actual feature specification file at `.github/features/apis/{endpoint}.md`. Replace all placeholders with appropriate values based on the provided input parameters.