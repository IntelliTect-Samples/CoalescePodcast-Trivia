import {
  Domain, getEnumMeta, solidify, ModelType, ObjectType,
  PrimitiveProperty, ForeignKeyProperty, PrimaryKeyProperty,
  ModelCollectionNavigationProperty, ModelReferenceNavigationProperty,
  HiddenAreas, BehaviorFlags
} from 'coalesce-vue/lib/metadata'


const domain: Domain = { enums: {}, types: {}, services: {} }
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
  },
}

interface AppDomain extends Domain {
  enums: {
  }
  types: {
    Answer: typeof Answer
    Question: typeof Question
  }
  services: {
  }
}

solidify(domain)

export default domain as unknown as AppDomain
