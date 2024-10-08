import {
  Domain, getEnumMeta, solidify, ModelType, ObjectType,
  PrimitiveProperty, ForeignKeyProperty, PrimaryKeyProperty,
  ModelCollectionNavigationProperty, ModelReferenceNavigationProperty,
  HiddenAreas, BehaviorFlags
} from 'coalesce-vue/lib/metadata'


const domain: Domain = { enums: {}, types: {}, services: {} }
export const AuditEntryState = domain.enums.AuditEntryState = {
  name: "AuditEntryState" as const,
  displayName: "Audit Entry State",
  type: "enum",
  ...getEnumMeta<"EntityAdded"|"EntityDeleted"|"EntityModified">([
  {
    value: 0,
    strValue: "EntityAdded",
    displayName: "Entity Added",
  },
  {
    value: 1,
    strValue: "EntityDeleted",
    displayName: "Entity Deleted",
  },
  {
    value: 2,
    strValue: "EntityModified",
    displayName: "Entity Modified",
  },
  ]),
}
export const Category = domain.enums.Category = {
  name: "Category" as const,
  displayName: "Category",
  type: "enum",
  ...getEnumMeta<"General"|"Science"|"History"|"Geography"|"Literature"|"Technology">([
  {
    value: 0,
    strValue: "General",
    displayName: "General",
  },
  {
    value: 1,
    strValue: "Science",
    displayName: "Science",
  },
  {
    value: 2,
    strValue: "History",
    displayName: "History",
  },
  {
    value: 3,
    strValue: "Geography",
    displayName: "Geography",
  },
  {
    value: 4,
    strValue: "Literature",
    displayName: "Literature",
  },
  {
    value: 5,
    strValue: "Technology",
    displayName: "Technology",
  },
  ]),
}
export const Answer = domain.types.Answer = {
  name: "Answer" as const,
  displayName: "Answer",
  get displayProp() { return this.props.text }, 
  type: "model",
  controllerRoute: "Answer",
  get keyProp() { return this.props.answerId }, 
  behaviorFlags: 7 as BehaviorFlags,
  props: {
    answerId: {
      name: "answerId",
      displayName: "Answer Id",
      type: "string",
      role: "primaryKey",
      hidden: 3 as HiddenAreas,
      createOnly: true,
    },
    text: {
      name: "text",
      displayName: "Text",
      type: "string",
      role: "value",
      rules: {
        required: val => (val != null && val !== '') || "Text is required.",
      }
    },
    questionId: {
      name: "questionId",
      displayName: "Question Id",
      type: "string",
      role: "foreignKey",
      get principalKey() { return (domain.types.Question as ModelType & { name: "Question" }).props.questionId as PrimaryKeyProperty },
      get principalType() { return (domain.types.Question as ModelType & { name: "Question" }) },
      get navigationProp() { return (domain.types.Answer as ModelType & { name: "Answer" }).props.question as ModelReferenceNavigationProperty },
      hidden: 3 as HiddenAreas,
      rules: {
        required: val => (val != null && val !== '') || "Question is required.",
      }
    },
    question: {
      name: "question",
      displayName: "Question",
      type: "model",
      get typeDef() { return (domain.types.Question as ModelType & { name: "Question" }) },
      role: "referenceNavigation",
      get foreignKey() { return (domain.types.Answer as ModelType & { name: "Answer" }).props.questionId as ForeignKeyProperty },
      get principalKey() { return (domain.types.Question as ModelType & { name: "Question" }).props.questionId as PrimaryKeyProperty },
      get inverseNavigation() { return (domain.types.Question as ModelType & { name: "Question" }).props.answers as ModelCollectionNavigationProperty },
      dontSerialize: true,
    },
  },
  methods: {
  },
  dataSources: {
    answersForQuestionDataSource: {
      type: "dataSource",
      name: "AnswersForQuestionDataSource" as const,
      displayName: "Answers For Question Data Source",
      props: {
        questionId: {
          name: "questionId",
          displayName: "Question Id",
          type: "string",
          role: "value",
        },
      },
    },
  },
}
export const AuditLog = domain.types.AuditLog = {
  name: "AuditLog" as const,
  displayName: "Audit Log",
  get displayProp() { return this.props.type }, 
  type: "model",
  controllerRoute: "AuditLog",
  get keyProp() { return this.props.id }, 
  behaviorFlags: 0 as BehaviorFlags,
  props: {
    id: {
      name: "id",
      displayName: "Id",
      type: "number",
      role: "primaryKey",
      hidden: 3 as HiddenAreas,
    },
    type: {
      name: "type",
      displayName: "Type",
      type: "string",
      role: "value",
      rules: {
        required: val => (val != null && val !== '') || "Type is required.",
        maxLength: val => !val || val.length <= 100 || "Type may not be more than 100 characters.",
      }
    },
    keyValue: {
      name: "keyValue",
      displayName: "Key Value",
      type: "string",
      role: "value",
    },
    description: {
      name: "description",
      displayName: "Description",
      type: "string",
      role: "value",
    },
    state: {
      name: "state",
      displayName: "Change Type",
      type: "enum",
      get typeDef() { return AuditEntryState },
      role: "value",
    },
    date: {
      name: "date",
      displayName: "Date",
      type: "date",
      dateKind: "datetime",
      role: "value",
    },
    properties: {
      name: "properties",
      displayName: "Properties",
      type: "collection",
      itemType: {
        name: "$collectionItem",
        displayName: "",
        role: "value",
        type: "model",
        get typeDef() { return (domain.types.AuditLogProperty as ModelType & { name: "AuditLogProperty" }) },
      },
      role: "collectionNavigation",
      get foreignKey() { return (domain.types.AuditLogProperty as ModelType & { name: "AuditLogProperty" }).props.parentId as ForeignKeyProperty },
      dontSerialize: true,
    },
    clientIp: {
      name: "clientIp",
      displayName: "Client IP",
      type: "string",
      role: "value",
    },
    referrer: {
      name: "referrer",
      displayName: "Referrer",
      type: "string",
      role: "value",
    },
    endpoint: {
      name: "endpoint",
      displayName: "Endpoint",
      type: "string",
      role: "value",
    },
  },
  methods: {
  },
  dataSources: {
  },
}
export const AuditLogProperty = domain.types.AuditLogProperty = {
  name: "AuditLogProperty" as const,
  displayName: "Audit Log Property",
  get displayProp() { return this.props.propertyName }, 
  type: "model",
  controllerRoute: "AuditLogProperty",
  get keyProp() { return this.props.id }, 
  behaviorFlags: 0 as BehaviorFlags,
  props: {
    id: {
      name: "id",
      displayName: "Id",
      type: "number",
      role: "primaryKey",
      hidden: 3 as HiddenAreas,
    },
    parentId: {
      name: "parentId",
      displayName: "Parent Id",
      type: "number",
      role: "foreignKey",
      get principalKey() { return (domain.types.AuditLog as ModelType & { name: "AuditLog" }).props.id as PrimaryKeyProperty },
      get principalType() { return (domain.types.AuditLog as ModelType & { name: "AuditLog" }) },
      rules: {
        required: val => val != null || "Parent Id is required.",
      }
    },
    propertyName: {
      name: "propertyName",
      displayName: "Property Name",
      type: "string",
      role: "value",
      rules: {
        required: val => (val != null && val !== '') || "Property Name is required.",
        maxLength: val => !val || val.length <= 100 || "Property Name may not be more than 100 characters.",
      }
    },
    oldValue: {
      name: "oldValue",
      displayName: "Old Value",
      type: "string",
      role: "value",
    },
    oldValueDescription: {
      name: "oldValueDescription",
      displayName: "Old Value Description",
      type: "string",
      role: "value",
    },
    newValue: {
      name: "newValue",
      displayName: "New Value",
      type: "string",
      role: "value",
    },
    newValueDescription: {
      name: "newValueDescription",
      displayName: "New Value Description",
      type: "string",
      role: "value",
    },
  },
  methods: {
  },
  dataSources: {
  },
}
export const Question = domain.types.Question = {
  name: "Question" as const,
  displayName: "Question",
  get displayProp() { return this.props.text }, 
  type: "model",
  controllerRoute: "Question",
  get keyProp() { return this.props.questionId }, 
  behaviorFlags: 7 as BehaviorFlags,
  props: {
    questionId: {
      name: "questionId",
      displayName: "Question Id",
      type: "string",
      role: "primaryKey",
      hidden: 3 as HiddenAreas,
      createOnly: true,
    },
    text: {
      name: "text",
      displayName: "Text",
      type: "string",
      role: "value",
      rules: {
        required: val => (val != null && val !== '') || "Text is required.",
      }
    },
    category: {
      name: "category",
      displayName: "Category",
      type: "enum",
      get typeDef() { return Category },
      role: "value",
    },
    correctAnswerId: {
      name: "correctAnswerId",
      displayName: "Correct Answer Id",
      type: "string",
      role: "foreignKey",
      get principalKey() { return (domain.types.Answer as ModelType & { name: "Answer" }).props.answerId as PrimaryKeyProperty },
      get principalType() { return (domain.types.Answer as ModelType & { name: "Answer" }) },
      get navigationProp() { return (domain.types.Question as ModelType & { name: "Question" }).props.correctAnswer as ModelReferenceNavigationProperty },
      hidden: 3 as HiddenAreas,
    },
    correctAnswer: {
      name: "correctAnswer",
      displayName: "Correct Answer",
      type: "model",
      get typeDef() { return (domain.types.Answer as ModelType & { name: "Answer" }) },
      role: "referenceNavigation",
      get foreignKey() { return (domain.types.Question as ModelType & { name: "Question" }).props.correctAnswerId as ForeignKeyProperty },
      get principalKey() { return (domain.types.Answer as ModelType & { name: "Answer" }).props.answerId as PrimaryKeyProperty },
      dontSerialize: true,
    },
    answers: {
      name: "answers",
      displayName: "Answers",
      type: "collection",
      itemType: {
        name: "$collectionItem",
        displayName: "",
        role: "value",
        type: "model",
        get typeDef() { return (domain.types.Answer as ModelType & { name: "Answer" }) },
      },
      role: "collectionNavigation",
      get foreignKey() { return (domain.types.Answer as ModelType & { name: "Answer" }).props.questionId as ForeignKeyProperty },
      get inverseNavigation() { return (domain.types.Answer as ModelType & { name: "Answer" }).props.question as ModelReferenceNavigationProperty },
      dontSerialize: true,
    },
  },
  methods: {
  },
  dataSources: {
    questionsDataSource: {
      type: "dataSource",
      name: "QuestionsDataSource" as const,
      displayName: "Questions Data Source",
      props: {
        correctAnswerText: {
          name: "correctAnswerText",
          displayName: "Correct Answer Text",
          type: "string",
          role: "value",
        },
      },
    },
  },
}
export const QuestionSummary = domain.types.QuestionSummary = {
  name: "QuestionSummary" as const,
  displayName: "Question Summary",
  get displayProp() { return this.props.id }, 
  type: "model",
  controllerRoute: "QuestionSummary",
  get keyProp() { return this.props.id }, 
  behaviorFlags: 0 as BehaviorFlags,
  props: {
    id: {
      name: "id",
      displayName: "Id",
      type: "string",
      role: "primaryKey",
      hidden: 3 as HiddenAreas,
    },
    text: {
      name: "text",
      displayName: "Text",
      type: "string",
      role: "value",
      rules: {
        required: val => (val != null && val !== '') || "Text is required.",
      }
    },
    answerCount: {
      name: "answerCount",
      displayName: "Answer Count",
      type: "number",
      role: "value",
      rules: {
        required: val => val != null || "Answer Count is required.",
      }
    },
    hasCorrectAnswer: {
      name: "hasCorrectAnswer",
      displayName: "Has Correct Answer",
      type: "boolean",
      role: "value",
      rules: {
        required: val => val != null || "Has Correct Answer is required.",
      }
    },
    category: {
      name: "category",
      displayName: "Category",
      type: "enum",
      get typeDef() { return Category },
      role: "value",
      rules: {
        required: val => val != null || "Category is required.",
      }
    },
  },
  methods: {
  },
  dataSources: {
    questionSummaryDataSource: {
      type: "dataSource",
      name: "QuestionSummaryDataSource" as const,
      displayName: "Question Summary Data Source",
      props: {
      },
    },
  },
}
export const PublicAnswerDto = domain.types.PublicAnswerDto = {
  name: "PublicAnswerDto" as const,
  displayName: "Public Answer Dto",
  type: "object",
  props: {
    answerId: {
      name: "answerId",
      displayName: "Answer Id",
      type: "string",
      role: "value",
      rules: {
        required: val => (val != null && val !== '') || "Answer Id is required.",
      }
    },
    text: {
      name: "text",
      displayName: "Text",
      type: "string",
      role: "value",
      rules: {
        required: val => (val != null && val !== '') || "Text is required.",
      }
    },
  },
}
export const PublicQuestionDto = domain.types.PublicQuestionDto = {
  name: "PublicQuestionDto" as const,
  displayName: "Public Question Dto",
  type: "object",
  props: {
    questionId: {
      name: "questionId",
      displayName: "Question Id",
      type: "string",
      role: "value",
      rules: {
        required: val => (val != null && val !== '') || "Question Id is required.",
      }
    },
    text: {
      name: "text",
      displayName: "Text",
      type: "string",
      role: "value",
      rules: {
        required: val => (val != null && val !== '') || "Text is required.",
      }
    },
    answers: {
      name: "answers",
      displayName: "Answers",
      type: "collection",
      itemType: {
        name: "$collectionItem",
        displayName: "",
        role: "value",
        type: "object",
        get typeDef() { return (domain.types.PublicAnswerDto as ObjectType & { name: "PublicAnswerDto" }) },
      },
      role: "value",
    },
  },
}
export const QuestionService = domain.services.QuestionService = {
  name: "QuestionService",
  displayName: "Question Service",
  type: "service",
  controllerRoute: "QuestionService",
  methods: {
    getRandomQuestion: {
      name: "getRandomQuestion",
      displayName: "Get Random Question",
      transportType: "item",
      httpMethod: "POST",
      params: {
      },
      return: {
        name: "$return",
        displayName: "Result",
        type: "object",
        get typeDef() { return (domain.types.PublicQuestionDto as ObjectType & { name: "PublicQuestionDto" }) },
        role: "value",
      },
    },
    guessAnswer: {
      name: "guessAnswer",
      displayName: "Guess Answer",
      transportType: "item",
      httpMethod: "POST",
      params: {
        answerId: {
          name: "answerId",
          displayName: "Answer Id",
          type: "string",
          role: "value",
          rules: {
            required: val => (val != null && val !== '') || "Answer Id is required.",
          }
        },
      },
      return: {
        name: "$return",
        displayName: "Result",
        type: "boolean",
        role: "value",
      },
    },
  },
}

interface AppDomain extends Domain {
  enums: {
    AuditEntryState: typeof AuditEntryState
    Category: typeof Category
  }
  types: {
    Answer: typeof Answer
    AuditLog: typeof AuditLog
    AuditLogProperty: typeof AuditLogProperty
    PublicAnswerDto: typeof PublicAnswerDto
    PublicQuestionDto: typeof PublicQuestionDto
    Question: typeof Question
    QuestionSummary: typeof QuestionSummary
  }
  services: {
    QuestionService: typeof QuestionService
  }
}

solidify(domain)

export default domain as unknown as AppDomain
