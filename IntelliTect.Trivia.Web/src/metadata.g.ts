import {
  Domain, getEnumMeta, solidify, ModelType, ObjectType,
  PrimitiveProperty, ForeignKeyProperty, PrimaryKeyProperty,
  ModelCollectionNavigationProperty, ModelReferenceNavigationProperty,
  HiddenAreas, BehaviorFlags
} from 'coalesce-vue/lib/metadata'


const domain: Domain = { enums: {}, types: {}, services: {} }
export const Category = domain.enums.Category = {
  name: "Category",
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
  name: "Answer",
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
      get principalKey() { return (domain.types.Question as ModelType).props.questionId as PrimaryKeyProperty },
      get principalType() { return (domain.types.Question as ModelType) },
      get navigationProp() { return (domain.types.Answer as ModelType).props.question as ModelReferenceNavigationProperty },
      hidden: 3 as HiddenAreas,
      rules: {
        required: val => (val != null && val !== '') || "Question is required.",
      }
    },
    question: {
      name: "question",
      displayName: "Question",
      type: "model",
      get typeDef() { return (domain.types.Question as ModelType) },
      role: "referenceNavigation",
      get foreignKey() { return (domain.types.Answer as ModelType).props.questionId as ForeignKeyProperty },
      get principalKey() { return (domain.types.Question as ModelType).props.questionId as PrimaryKeyProperty },
      get inverseNavigation() { return (domain.types.Question as ModelType).props.answers as ModelCollectionNavigationProperty },
      dontSerialize: true,
    },
  },
  methods: {
  },
  dataSources: {
    answersForQuestionDataSource: {
      type: "dataSource",
      name: "AnswersForQuestionDataSource",
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
export const AppUser = domain.types.AppUser = {
  name: "AppUser",
  displayName: "App User",
  get displayProp() { return this.props.id }, 
  type: "model",
  controllerRoute: "AppUser",
  get keyProp() { return this.props.id }, 
  behaviorFlags: 7 as BehaviorFlags,
  props: {
    id: {
      name: "id",
      displayName: "Id",
      type: "string",
      role: "primaryKey",
      hidden: 3 as HiddenAreas,
    },
    userName: {
      name: "userName",
      displayName: "User Name",
      type: "string",
      role: "value",
    },
    normalizedUserName: {
      name: "normalizedUserName",
      displayName: "Normalized User Name",
      type: "string",
      role: "value",
    },
    email: {
      name: "email",
      displayName: "Email",
      type: "string",
      role: "value",
    },
    normalizedEmail: {
      name: "normalizedEmail",
      displayName: "Normalized Email",
      type: "string",
      role: "value",
    },
    emailConfirmed: {
      name: "emailConfirmed",
      displayName: "Email Confirmed",
      type: "boolean",
      role: "value",
    },
    passwordHash: {
      name: "passwordHash",
      displayName: "Password Hash",
      type: "string",
      role: "value",
    },
    securityStamp: {
      name: "securityStamp",
      displayName: "Security Stamp",
      type: "string",
      role: "value",
    },
    concurrencyStamp: {
      name: "concurrencyStamp",
      displayName: "Concurrency Stamp",
      type: "string",
      role: "value",
    },
    phoneNumber: {
      name: "phoneNumber",
      displayName: "Phone Number",
      type: "string",
      role: "value",
    },
    phoneNumberConfirmed: {
      name: "phoneNumberConfirmed",
      displayName: "Phone Number Confirmed",
      type: "boolean",
      role: "value",
    },
    twoFactorEnabled: {
      name: "twoFactorEnabled",
      displayName: "Two Factor Enabled",
      type: "boolean",
      role: "value",
    },
    lockoutEnd: {
      name: "lockoutEnd",
      displayName: "Lockout End",
      type: "date",
      dateKind: "datetime",
      role: "value",
    },
    lockoutEnabled: {
      name: "lockoutEnabled",
      displayName: "Lockout Enabled",
      type: "boolean",
      role: "value",
    },
    accessFailedCount: {
      name: "accessFailedCount",
      displayName: "Access Failed Count",
      type: "number",
      role: "value",
    },
  },
  methods: {
  },
  dataSources: {
  },
}
export const Question = domain.types.Question = {
  name: "Question",
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
      get typeDef() { return domain.enums.Category },
      role: "value",
    },
    correctAnswerId: {
      name: "correctAnswerId",
      displayName: "Correct Answer Id",
      type: "string",
      role: "foreignKey",
      get principalKey() { return (domain.types.Answer as ModelType).props.answerId as PrimaryKeyProperty },
      get principalType() { return (domain.types.Answer as ModelType) },
      get navigationProp() { return (domain.types.Question as ModelType).props.correctAnswer as ModelReferenceNavigationProperty },
      hidden: 3 as HiddenAreas,
    },
    correctAnswer: {
      name: "correctAnswer",
      displayName: "Correct Answer",
      type: "model",
      get typeDef() { return (domain.types.Answer as ModelType) },
      role: "referenceNavigation",
      get foreignKey() { return (domain.types.Question as ModelType).props.correctAnswerId as ForeignKeyProperty },
      get principalKey() { return (domain.types.Answer as ModelType).props.answerId as PrimaryKeyProperty },
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
        get typeDef() { return (domain.types.Answer as ModelType) },
      },
      role: "collectionNavigation",
      get foreignKey() { return (domain.types.Answer as ModelType).props.questionId as ForeignKeyProperty },
      get inverseNavigation() { return (domain.types.Answer as ModelType).props.question as ModelReferenceNavigationProperty },
      dontSerialize: true,
    },
  },
  methods: {
  },
  dataSources: {
    questionsDataSource: {
      type: "dataSource",
      name: "QuestionsDataSource",
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
        type: "model",
        get typeDef() { return (domain.types.Question as ModelType) },
        role: "value",
      },
    },
  },
}

interface AppDomain extends Domain {
  enums: {
    Category: typeof Category
  }
  types: {
    Answer: typeof Answer
    AppUser: typeof AppUser
    Question: typeof Question
  }
  services: {
    QuestionService: typeof QuestionService
  }
}

solidify(domain)

export default domain as unknown as AppDomain
